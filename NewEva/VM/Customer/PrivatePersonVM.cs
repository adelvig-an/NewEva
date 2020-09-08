﻿using NewEva.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewEva.VM
{
    public class PrivatePersonVM : PageVM
    {
        public PrivatePerson PrivatePerson { get; }
        public Address Registration { get; }
        public Address Actual { get; private set; }
        public IEnumerable<string> TypeDocs { get; }

        private bool isAddressMatch;
        public bool IsAddressMatch
        {
            get => isAddressMatch;
            set
            {
                SetProperty(ref isAddressMatch, value);
                if (value == true)
                {
                    Actual = Registration;
                }
                OnPropertyChanged(nameof(Actual));
            }
        }

        public PrivatePersonVM()
        {
            PrivatePerson = new PrivatePerson()
            {
                SecondName = "Иванов",
                FirstName = "Иван",
                MiddleName = "Иванович",
                Serial = "04 02",
                Number = "245856",
                Issued = "МВД г. Мухосранска",
                Division = "025-046",
                DateIssued = DateTime.Today
            };

            TypeDocs = LocalStorage.TypeDocs;

            Registration = new Address()
            {
                AddressFull = "662145, Российская Федерация, Смоленская область, Велижский район, г. Велиж, ул. Маяковского, д. 15, кв. 6",
                Index = 662145,
                Country = "Российская Федерация",
                Region = "Смоленская область",
                District = "Велижский район",
                City = "Велиж",
                Street = "Маяковского",
                House = "15",
                Room = "6"
            };

            Actual = new Address()
            {
                AddressFull = "266542, Российская Федерация, Саратовская область, Аркадакский район, г. Аркадак, ул. Горького, д. 8, кв. 16",
                Index = 266542,
                Country = "Российская Федерация",
                Region = "Саратовская область",
                District = "Аркадакский район",
                City = "Аркадак",
                Street = "Горького",
                House = "8",
                Room = "16"
            };
        }

        private string isTypeDocs;
        public string IsTypeDocs
        {
            get => isTypeDocs;
            set => SetProperty(ref isTypeDocs, value);
        }

    }
}