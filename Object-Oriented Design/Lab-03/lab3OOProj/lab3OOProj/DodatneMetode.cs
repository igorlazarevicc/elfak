using System;
using System.Windows.Forms;

namespace lab3OOProj
{
  
    public static class DodatneMetode
    {
     
        public static string TrenutnoVreme(this DateTime dt)
        {
            return DateTime.Now.ToString("dd.MM.yyyy. HH:mm");
        }

     
        public static void OcistiPolja(TextBox t1, TextBox t2, TextBox t3, TextBox t4, DateTimePicker dtp)
        {
            t1.Clear();
            t2.Clear();
            t3.Clear();
            t4.Clear();

       
            dtp.Value = DateTime.Now;
        }

     
        public static void PopuniComBox(ComboBox cb)
        {
            cb.Items.Add("PO IMENU");
            cb.Items.Add("PO PREZIMENU");
            cb.Items.Add("PO DATUMU RODJENJA");

        
            if (cb.Items.Count > 0) cb.SelectedIndex = 0;
        }
    }
}