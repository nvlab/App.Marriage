using App.Marriage.DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Marriage.Models.PersonMV
{
    public class PersonViewModel
    {
        #region Properties
        private int _Id;
        private int? _Nationality_Id;
        private string _FullName;
        private string _Mother;
        private string _Father;
        private int? _Age;
        private DateTime? _BirthDate;
        private int? _Weight;
        private string _NationalityNumber;
        private int? _User_Id;
        private string _Photo2;
        private string _Photo1;
        private string _Gender;
        private string _Color;
        private int? _SocialStatus;
        private int? _Residence_Country_Id;
        private string _Adress;
        private string _PlaceBirth;
        private int? _height;
        private string _Phone1;
        private string _Phone2;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        public int? Nationality_Id
        {
            get { return _Nationality_Id; }
            set { _Nationality_Id = value; }
        }
        public string FullName
        {
            get { return _FullName; }
            set { _FullName = value; }
        }


        public string Father
        {
            get { return _Father; }
            set { _Father = value; }
        }



        public string Mother
        {
            get { return _Mother; }
            set { _Mother = value; }
        }


        public int? Age
        {
            get { return _Age; }
            set { _Age = value; }
        }


        public DateTime? BirthDate
        {
            get { return _BirthDate; }
            set { _BirthDate = value; }
        }


        public int? height
        {
            get { return _height; }
            set { _height = value; }
        }

        public int? Weight
        {
            get { return _Weight; }
            set { _Weight = value; }
        }


        public string PlaceBirth
        {
            get { return _PlaceBirth; }
            set { _PlaceBirth = value; }
        }

        public string Adress
        {
            get { return _Adress; }
            set { _Adress = value; }
        }

        public int? Residence_Country_Id
        {
            get { return _Residence_Country_Id; }
            set { _Residence_Country_Id = value; }
        }

        public int? SocialStatus
        {
            get { return _SocialStatus; }
            set { _SocialStatus = value; }
        }

        public string Color
        {
            get { return _Color; }
            set { _Color = value; }
        }

        public string Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        }

        public string Photo1
        {
            get { return _Photo1; }
            set { _Photo1 = value; }
        }

        public string Photo2
        {
            get { return _Photo2; }
            set { _Photo2 = value; }
        }

        public int? User_Id
        {
            get { return _User_Id; }
            set { _User_Id = value; }
        }

        public string NationalityNumber
        {
            get { return _NationalityNumber; }
            set { _NationalityNumber = value; }
        }
        private string _PassportNumber;

        public string PassportNumber
        {
            get { return _PassportNumber; }
            set { _PassportNumber = value; }
        }
        private string _Email;

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        private bool _IsActive;

        public bool IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }

        public string Phone1
        {
            get { return _Phone1; }
            set { _Phone1 = value; }
        }


        public string Phone2
        {
            get { return _Phone2; }
            set { _Phone2 = value; }
        }

        #endregion
        #region Construction Functions

        public PersonViewModel()
        {
        }

        public PersonViewModel(PersonDAL Pa)
        {
            _Id = Pa.Persons.Id;
            _Nationality_Id = Pa.Persons.Nationality_Id;
            _FullName = Pa.Persons.FullName;
            _Mother = Pa.Persons.Mother;
            _Father = Pa.Persons.Father;
            _Age = Pa.Persons.Age;
            _BirthDate = Pa.Persons.BirthDate;
            _Weight = Pa.Persons.Weight;
            _NationalityNumber = Pa.Persons.NationalityNumber;
            _User_Id = Pa.Persons.User_Id;
            _Photo2 = Pa.Persons.Photo2;
            _Photo1 = Pa.Persons.Photo1;
            _Gender = Pa.Persons.Gender;
            _Color = Pa.Persons.Color;
            _SocialStatus = Pa.Persons.SocialStatus;
            _Residence_Country_Id = Pa.Persons.Residence_Country_Id;
            _Adress = Pa.Persons.Adress;
            _PlaceBirth = Pa.Persons.PlaceBirth;
            _height = Pa.Persons.height;
            _Phone1 = Pa.Persons.Phone1;
            _Phone2 = Pa.Persons.Phone2;


        }
        public PersonViewModel(int Id
        , int NationalityId
        , string FullName
        , string Mother
        , string Father
        , int Age
        , DateTime BirthDate
        , int Weight
        , string NationalityNumber
        , int UserId
        , string Photo2
        , string Photo1
        , string Gender
        , string Color
        , int SocialStatus
        , int ResidenceCountryId
        , string Adress
        , string PlaceBirth
        , int height
        , string Phone1
        , string Phone2)
        {
            _Id = Id;
            _Nationality_Id = Nationality_Id;
            _FullName = FullName;
            _Mother = Mother;
            _Father = Father;
            _Age = Age;
            _BirthDate = BirthDate;
            _Weight = Weight;
            _NationalityNumber = NationalityNumber;
            _User_Id = User_Id;
            _Photo2 = Photo2;
            _Photo1 = Photo1;
            _Gender = Gender;
            _Color = Color;
            _SocialStatus = SocialStatus;
            _Residence_Country_Id = Residence_Country_Id;
            _Adress = Adress;
            _PlaceBirth = PlaceBirth;
            _height = height;
            _Phone1 = Phone1;
            _Phone2 = Phone2;

        }
        public PersonViewModel(int Id)
        {
            _Id = Id;
        }
        public PersonViewModel(object item)
        {
            Type type = item.GetType();
            _Id = (int)type.GetProperty("Id").GetValue(item, null);
            _Nationality_Id = (int)type.GetProperty("Nationality_Id ").GetValue(item, null);
            _FullName = (string)type.GetProperty("FullName").GetValue(item, null);
            _Mother = (string)type.GetProperty("Mother").GetValue(item, null);
            _Father = (string)type.GetProperty("Father").GetValue(item, null);
            _Age = (int)type.GetProperty("Age").GetValue(item, null);
            _BirthDate = (DateTime)type.GetProperty("BirthDate").GetValue(item, null);
            _Weight = (int)type.GetProperty("Weight").GetValue(item, null);
            _NationalityNumber = (string)type.GetProperty("NationalityNumber").GetValue(item, null);
            _User_Id = (int)type.GetProperty("User_Id").GetValue(item, null);
            _Photo2 = (string)type.GetProperty("Photo2").GetValue(item, null);
            _Photo1 = (string)type.GetProperty("Photo1").GetValue(item, null);
            _Gender = (string)type.GetProperty("Gender").GetValue(item, null);
            _Color = (string)type.GetProperty("Color").GetValue(item, null);
            _SocialStatus = (int)type.GetProperty("SocialStatus").GetValue(item, null);
            _Residence_Country_Id = (int)type.GetProperty("Residence_Country_Id").GetValue(item, null);
            _Adress = (string)type.GetProperty("Adress ").GetValue(item, null);
            _PlaceBirth = (string)type.GetProperty("PlaceBirth").GetValue(item, null);
            _height = (int)type.GetProperty("height").GetValue(item, null);
            _Phone1 = (string)type.GetProperty("Phone1").GetValue(item, null);
            _Phone2 = (string)type.GetProperty("Phone2").GetValue(item, null);

        }

        #endregion
        #region Operation Main Functions

        public void Create()
        {
            PersonDAL Pa = new PersonDAL();
            Pa.Persons.Id = _Id;
            Pa.Persons.Nationality_Id = _Nationality_Id;
            Pa.Persons.FullName = _FullName;
            Pa.Persons.Mother = _Mother;
            Pa.Persons.Father = _Father;
            Pa.Persons.Age = _Age;
            Pa.Persons.BirthDate = _BirthDate;
            Pa.Persons.Weight = _Weight;
            Pa.Persons.NationalityNumber = _NationalityNumber;
            Pa.Persons.User_Id = _User_Id;
            Pa.Persons.Photo2 = _Photo2;
            Pa.Persons.Photo1 = _Photo1;
            Pa.Persons.Gender = _Gender;
            Pa.Persons.Color = _Color;
            Pa.Persons.SocialStatus = _SocialStatus;
            Pa.Persons.Residence_Country_Id = _Residence_Country_Id;
            Pa.Persons.Adress = _Adress;
            Pa.Persons.PlaceBirth = _PlaceBirth;
            Pa.Persons.height = _height;
            Pa.Persons.Phone1 = _Phone1;
            Pa.Persons.Phone2 = _Phone2;

            Pa.Create();

            _Id = Pa.Persons.Id;
        }

        public void Update()
        {
            PersonDAL Pa = new PersonDAL(_Id);
            DateTime Validate = new DateTime();
            if (_Nationality_Id != 0 && _Nationality_Id != null) { Pa.Persons.Nationality_Id = _Nationality_Id; }
            if (_Residence_Country_Id != 0 && _Residence_Country_Id != null) { Pa.Persons.Residence_Country_Id = _Residence_Country_Id; }
            if (_User_Id != 0 && _User_Id != null) { Pa.Persons.User_Id = _User_Id; }

            if (!string.IsNullOrEmpty(_FullName)) { Pa.Persons.FullName = _FullName; }
            if (!string.IsNullOrEmpty(_Mother)) { Pa.Persons.Mother = _Mother; }
            if (!string.IsNullOrEmpty(_Father)) { Pa.Persons.Father = _Father; }
            if (!string.IsNullOrEmpty(_Phone1)) { Pa.Persons.Phone1 = _Phone1; }
            if (!string.IsNullOrEmpty(_Phone2)) { Pa.Persons.Phone2 = _Phone2; }
            if (!string.IsNullOrEmpty(_NationalityNumber)) { Pa.Persons.NationalityNumber = _NationalityNumber; }
            if (!string.IsNullOrEmpty(_Gender)) { Pa.Persons.Gender = _Gender; }
            if (!string.IsNullOrEmpty(_Color)) { Pa.Persons.Color = _Color; }
            if (!string.IsNullOrEmpty(_Adress)) { Pa.Persons.Adress = _Adress; }
            if (!string.IsNullOrEmpty(_PlaceBirth)) { Pa.Persons.PlaceBirth = _PlaceBirth; }


            if (_Age != null) { Pa.Persons.Age = _Age; }
            if (_SocialStatus != null) { Pa.Persons.SocialStatus = _SocialStatus; }
            if (_Weight != null) { Pa.Persons.Weight = _Weight; }
            if (_height != null) { Pa.Persons.height = _height; }





            if (Validate != _BirthDate) { Pa.Persons.BirthDate = _BirthDate; }

            Pa.Update();
        }

        public void Delete()
        {
            PersonDAL Pa = new PersonDAL(_Id);
            Pa.Delete();
        }


        #endregion
        #region Business Function
        public static List<PersonViewModel> GetPersonList()
        {
            List<PersonViewModel> List = new List<PersonViewModel>();
            PersonDAL.GetPersonsssList().ForEach(r => List.Add(new PersonViewModel(r)));
            return List;
        }

        public static IEnumerable GetPersonsComboList()
        {
            return PersonDAL.GetPersonsComboList();
        }

        #endregion
    }
}