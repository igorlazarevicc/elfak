; 1. Primer Međuprenosa
; 2. Primer izlaznog prenosa 
; 3. Međurezultat jednak nuli
; 4. OStatak pri deljenju 
; 5. Greška - deljenje nulom

;MOV AX, 0X02 ; MOV EBX, 0XFFFFFFF6 -- Primer izlaznog prenosa
;MOV AX, 0X01 ; MOV EBX, 0X000001F4 -- Međurezultat jednak nuli
;MOV AX, 0X02; MOV EBX, 0X00000005 -- OStatak pri deljenju 
;MOV AX, 0X00; MOV EBX, 0XFFFFFFF0 -- Greška - deljenje nulom

; Primer Međuprenosa

MOV AX, 127         ; B1 = 127
MOVSX EAX, AX       
AND EAX, 0x0000000F ; Zadrži niži polubajt (0x00000007)
OR EAX, 0xFFFFFFF0  ; Napravi [B1*] (0xFFFFFFFF, što je -1)
MOV EBX, 100000000  ; B2 = 100,000,000
SUB EAX, EBX        ; -1 - 100,000,000 = -100,000,001
MOV ECX, EAX        ; ECX = -100,000,001

; --- 2. BROJILAC (10 + B2 * (B1 - 1)) ---
MOV AX, 127         ; B1
MOVSX EAX, AX       
DEC EAX             ; 126
MOV EBX, 100000000  ; B2
IMUL EBX            ; EDX:EAX = 12,600,000,000 (MEĐUPRENOS u EDX), za ovaj primer
ADD EAX, 10         ; Dodaj 10
ADC EDX, 0          ; Prenesi Carry (IZLAZNI PRENOS)

; --- 3. DELJENJE I SAR ---
IDIV ECX            ; EAX = -125 (Količnik), EDX = 99,999,885 (Ostatak)
SAR EAX, 2          ; -125 / 4 = -32
