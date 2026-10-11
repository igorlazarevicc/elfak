.MODEL SMALL
.STACK 100h

ROWS EQU 4
COLS EQU 5

.DATA
    MAT DW 1,  2,  3,  4,  5
        DW 6,  7,  8,  9, 10
        DW 11, 12, 13, 14, 15
        DW 16, 17, 18, 19, 20

.CODE

ROTATE PROC NEAR
    PUSH BP
    MOV  BP, SP
    SUB  SP, 4

    PUSH AX
    PUSH BX
    PUSH CX
    PUSH DX
    PUSH SI
    PUSH DI

    ; Lokalna promenljiva [BP-2] = K mod N
    ; Lokalna promenljiva [BP-4] = smer rotacije

    MOV  AX, [BP+6]
    XOR  DX, DX
    DIV  CX
    MOV  [BP-2], DX

    MOV  AX, [BP+8]
    MOV  [BP-4], AX

ROTATE_LOOP:
    CMP  WORD PTR [BP-2], 0
    JE   ROTATE_DONE

    DEC  WORD PTR [BP-2]

    MOV  SI, [BP+4]

    CMP  WORD PTR [BP-4], 0
    JNE  ROTATE_RIGHT

ROTATE_LEFT:
    MOV  AX, [SI]       ; Sacuvaj prvi element
    MOV  BX, CX
    DEC  BX             ; N - 1 pomeranja

LEFT_LOOP:
    MOV  DX, [SI+2]
    MOV  [SI], DX
    ADD  SI, 2
    DEC  BX
    JNZ  LEFT_LOOP

    MOV  [SI], AX       ; Prvi element ide na kraj

    JMP  ROTATE_LOOP

ROTATE_RIGHT:
    MOV  DI, CX
    DEC  DI
    SHL  DI, 1          ; (N - 1) * 2 bajta
    ADD  SI, DI         ; SI pokazuje na poslednji element

    MOV  AX, [SI]       ; Sacuvaj poslednji element
    MOV  BX, CX
    DEC  BX

RIGHT_LOOP:
    MOV  DX, [SI-2]
    MOV  [SI], DX
    SUB  SI, 2
    DEC  BX
    JNZ  RIGHT_LOOP

    MOV  [SI], AX       ; Poslednji element ide na pocetak

    JMP  ROTATE_LOOP

ROTATE_DONE:
    POP  DI
    POP  SI
    POP  DX
    POP  CX
    POP  BX
    POP  AX

    MOV  SP, BP
    POP  BP

    RET  6
ROTATE ENDP

MAIN PROC
    MOV  AX, @DATA
    MOV  DS, AX

    MOV  SI, OFFSET MAT
    MOV  DI, 1          ; Indeks vrste: i = 1

ROW_LOOP:
    CMP  DI, ROWS
    JA   PROGRAM_END

    ; Odredi smer:
    ; 0 = ulevo, 1 = udesno

    XOR  AX, AX
    TEST DI, 1
    JZ   DIRECTION_READY

    MOV  AX, 1

DIRECTION_READY:
    PUSH AX             ; Smer rotacije
    PUSH DI             ; K = i
    PUSH SI             ; Adresa tekuce vrste

    MOV  CX, COLS       ; Broj elemenata u vrsti
    CALL ROTATE

    ADD  SI, COLS * 2   ; Sledeca vrsta
    INC  DI

    JMP  ROW_LOOP

PROGRAM_END:
    MOV  AX, 4C00h
    INT  21h

MAIN ENDP

END MAIN
