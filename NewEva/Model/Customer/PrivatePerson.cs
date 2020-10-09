using NewEva.DbLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace NewEva.Model
{
    public class PrivatePerson : Person, IDataErrorInfo
    {
        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "TypePassport":
                        if (TypePassport == null)
                            error = "Не выбран документ удостоверяющий личность не заполненно!\nВыбрать документ удостоверяющий личность!";
                        break;
                    case "Serial":
                        if (Serial == null)
                            error = "Серия документа удостоверяющего личность не заполненно!\nЗаполнить Серию документа удостоверяющий личность!";
                        else if (Serial.Length != 4)
                            error = "Серия документа  должен состоять из 4 символов!";
                        break;
                    case "Number":
                        if (Number == null)
                            error = "Номер документа удостоверяющего личность не заполненно!\nЗаполнить Номер документ удостоверяющий личность!";
                        else if (Number.Length != 6)
                            error = "Номер документа должен состоять из 6 символов!";
                        break;
                    case "Issued":
                        if (Issued == null)
                        {
                            error = "Орган выдавший документ удостоверяющий личность не заполнен!\nЗаполнить Орган выдавший документ удостоверяющий личность!";
                        }
                        break;
                    case "Division":
                        if (Division == null)
                            error = "Код поазделения документа удостоверяющего личность не заполнен!\nЗаполнить Код подразделения документа удостоверяющего личность!";
                        else if (Number.Length != 6)
                            error = "Номер документа должен состоять из 6 символов!";
                        break;
                    case "DateIssued":
                        if (DateIssued == DateTime.Today)
                            error = "Не верная дата выдачи документа удостоверяющего личность не заполнен!\nУказать верную дату выдачи документа удостоверяющего личность!";
                        break;
                }
                return error;
            }
        }

        public int Id { get; set; }
        public string TypePassport { get; set; } //Тип документа подтверждающего личность
        public string Serial { get; set; } //Серия документа
        public string Number { get; set; } //Номер документа
        public string Issued { get; set; } //Кем выдан документ
        public string Division { get; set; } //Код подразделения
        public DateTime DateIssued { get; set; } //Дата выдачи

        public string Error => "";
    }
}
