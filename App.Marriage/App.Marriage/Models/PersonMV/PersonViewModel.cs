using App.Marriage.DAL;
using App.Marriage.Entities;
using App.Marriage.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        string _Photo2;
        string _Photo1;
        private string _Gender;
        private string _Color;
        private int? _SocialStatus;
        private int? _Residence_Country_Id;
        private string _Adress;
        private string _PlaceBirth;
        private int? _height;
        private string _Phone1;
        private string _Phone2;
        private string _GeneralInfo;



        private bool? _IsActive;
        private string _Email;
        private string _PassportNumber;


        private string _NickName;
        private string _SurName;
        private string _CountryState;
        private byte? _ChildCount;
        private byte? _MaxChildAge;
        private byte? _MinChildAge;

        private string _Education;
        private string _EducationBranch;
        private string _WorkType;
        private string _Languages;
        private string _LivingLevel;
        private string _Theams;
        private string _Hobbies;
        private string _Culture;
        private string _CultureLevel;




        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
      
        [Range(1,int.MaxValue,ErrorMessage = "يجب ادخال الجنسية")]
        public int? Nationality_Id
        {
            get { return _Nationality_Id; }
            set { _Nationality_Id = value; }
        }
        [Required(ErrorMessage = "يجب ادخال الاسم")]
        [StringLength(200, MinimumLength = 2 ,ErrorMessage ="ادخل الاسم بشكل صحيح")]
        //[RegularExpression("[^0-9]", ErrorMessage = "أدخل أحرف فقط")]
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

        [Range(15, 50, ErrorMessage = "يجب أن يكون العمر مابين 15 و 50")]
        public int? Age
        {
            get { return _Age; }
            set { _Age = value; }
        }

        [Required(ErrorMessage = "يجب ادخال تاريخ الولادة")]
        
        public DateTime? BirthDate
        {
            get { return _BirthDate; }
            set { _BirthDate = value; }
        }

        [Range(145, 200, ErrorMessage = "يجب أن يكون الطول مابين 145 و 200")]
        public int? Height
        {
            get { return _height; }
            set { _height = value; }
        }

        [Range(40, 200, ErrorMessage = "يجب أن يكون الوزن مابين 40 و 200")]
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

        [StringLength(200, MinimumLength = 0, ErrorMessage = "لقد تجاوزت عدد الأحرف المسموح به لحقل العنوان، وهو 200 حرف")]
        public string Adress
        {
            get { return _Adress; }
            set { _Adress = value; }
        }

        
        [Range(1,int.MaxValue, ErrorMessage = "يجب ادخال دولة الاقامة الحالية")]
        public int? Residence_Country_Id
        {
            get { return _Residence_Country_Id; }
            set { _Residence_Country_Id = value; }
        }

      
        [Range(1,int.MaxValue,ErrorMessage = "يجب ادخال الحالة الاجتماعية")]
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


        public string PassportNumber
        {
            get { return _PassportNumber; }
            set { _PassportNumber = value; }
        }


        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }


        public bool? IsActive
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
        public string GeneralInfo
        {
            get { return _GeneralInfo; }
            set { _GeneralInfo = value; }
        }

        public string NickName
        {
            get { return _NickName; }
            set { _NickName = value; }
        }
        public string SurName
        {
            get { return _SurName; }
            set { _SurName = value; }
        }
        public string CountryState
        {
            get { return _CountryState; }
            set { _CountryState = value; }
        }
        [Range(0, 15, ErrorMessage = "أدخل رقم بين 0 و 15")]
        public byte? ChildCount
        {
            get { return _ChildCount; }
            set { _ChildCount = value; }
        }
        [Range(0, 40, ErrorMessage = "أدخل رقم بين 0 و 40")]
        public byte? MaxChildAge
        {
            get { return _MaxChildAge; }
            set { _MaxChildAge = value; }
        }
        [Range(0, 40, ErrorMessage = "أدخل رقم بين 0 و 40")]
        public byte? MinChildAge
        {
            get { return _MinChildAge; }
            set { _MinChildAge = value; }
        }

        [Required(ErrorMessage = "يجب ادخال مستوى التعليم")]
        public string Education
        {
            get { return _Education; }
            set { _Education = value; }
        }

        public string EducationBranch
        {
            get { return _EducationBranch; }
            set { _EducationBranch = value; }
        }

        [Required(ErrorMessage = "يجب ادخال العمل")]
        public string WorkType
        {
            get { return _WorkType; }
            set { _WorkType = value; }
        }
        [StringLength(100, MinimumLength = 2, ErrorMessage = "الحد المسموح به هو 100 حرف")]
        public string Languages
        {
            get { return _Languages; }
            set { _Languages = value; }
        }

        public string LivingLevel
        {
            get { return _LivingLevel; }
            set { _LivingLevel = value; }
        }

        [StringLength(500, MinimumLength = 0, ErrorMessage = "الحد المسموح به هو 500 حرف ")]
        public string Theams
        {
            get { return _Theams; }
            set { _Theams = value; }
        }
        [StringLength(255, MinimumLength = 0, ErrorMessage = "الحد المسموح به هو 255 حرف ")]
        public string Hobbies
        {
            get { return _Hobbies; }
            set { _Hobbies = value; }
        }

        public string Culture
        {
            get { return _Culture; }
            set { _Culture = value; }
        }

        public string CultureLevel
        {
            get { return _CultureLevel; }
            set { _CultureLevel = value; }
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
            _GeneralInfo = Pa.Persons.GeneralInfo;
            _Email = Pa.Persons.Email;
            _PassportNumber = Pa.Persons.PassportNumber;
            _IsActive = Pa.Persons.IsActive;
            _NickName = Pa.Persons.NickName;
            _SurName = Pa.Persons.SurName;
            _CountryState = Pa.Persons.CountryState;
            _ChildCount = Pa.Persons.ChildCount;
            _MaxChildAge = Pa.Persons.MaxChildAge;
            _MinChildAge = Pa.Persons.MinChildAge;
            _Education = Pa.Persons.Education;
            _EducationBranch = Pa.Persons.EducationBranch;
            _WorkType = Pa.Persons.WorkType;
            _Languages = Pa.Persons.Languages;
            _LivingLevel = Pa.Persons.LivingLevel;
            _Theams = Pa.Persons.Theams;
            _Hobbies = Pa.Persons.Hobbies;
            _Culture = Pa.Persons.Culture;
            _CultureLevel = Pa.Persons.CultureLevel;

            ReadCustomizeFld(_Id);

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
        , string Phone2
        , string GeneralInfo
        , string NickName,
        string SurName,
        string CountryState,
        byte? ChildCount,
        byte? MaxChildAge,
        byte? MinChildAge,
        string Education,
        string EducationBranch,
        string WorkType,
        string Languages,
        string LivingLevel,
        string Theams,
        string Hobbies,
        string Culture,
        string CultureLevel)
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
            _GeneralInfo = GeneralInfo;
            _NickName = NickName;
            _SurName = SurName;
            _CountryState = CountryState;
            _ChildCount = ChildCount;
            _MaxChildAge = MaxChildAge;
            _MinChildAge = MinChildAge;
            _Education = Education;
            _EducationBranch = EducationBranch;
            _WorkType = WorkType;
            _Languages = Languages;
            _LivingLevel = LivingLevel;
            _Theams = Theams;
            _Hobbies = Hobbies;
            _Culture = Culture;
            _CultureLevel = CultureLevel;

        }
        public PersonViewModel(int Id)
        {
            _Id = Id;
        }
        public PersonViewModel(object item)
        {
            Type type = item.GetType();
            _Id = (int)type.GetProperty("Id").GetValue(item, null);
            _Nationality_Id = (int)type.GetProperty("Nationality_Id").GetValue(item, null);
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
            _Adress = (string)type.GetProperty("Adress").GetValue(item, null);
            _PlaceBirth = (string)type.GetProperty("PlaceBirth").GetValue(item, null);
            _height = (int)type.GetProperty("height").GetValue(item, null);
            _Phone1 = (string)type.GetProperty("Phone1").GetValue(item, null);
            _Phone2 = (string)type.GetProperty("Phone2").GetValue(item, null);
            _GeneralInfo = (string)type.GetProperty("GeneralInfo").GetValue(item, null);
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
            Pa.Persons.GeneralInfo = _GeneralInfo;
            Pa.Persons.NickName = _NickName;
            Pa.Persons.SurName = _SurName;
            Pa.Persons.CountryState = _CountryState;
            Pa.Persons.ChildCount = _ChildCount;
            Pa.Persons.MaxChildAge = _MaxChildAge;
            Pa.Persons.MinChildAge = _MinChildAge;
            Pa.Persons.Education = _Education;
            Pa.Persons.EducationBranch = _EducationBranch;
            Pa.Persons.WorkType = _WorkType;
            Pa.Persons.Languages = _Languages;
            Pa.Persons.LivingLevel = _LivingLevel;
            Pa.Persons.Theams = _Theams;
            Pa.Persons.Hobbies = _Hobbies;
            Pa.Persons.Culture = _Culture;
            Pa.Persons.CultureLevel = _CultureLevel;
            Pa.Persons.PassportNumber = _PassportNumber;
            Pa.Persons.Email = _Email;


            Pa.Create();

            _Id = Pa.Persons.Id;
        }

        public void Update()
        {
            PersonDAL Pa = new PersonDAL(_Id);
            DateTime Validate = new DateTime();
            if (_Nationality_Id != 0 && _Nationality_Id != null) { Pa.Persons.Nationality_Id = _Nationality_Id; }
            if (_Residence_Country_Id != 0 && _Residence_Country_Id != null) { Pa.Persons.Residence_Country_Id = _Residence_Country_Id; }
           

            if (!string.IsNullOrEmpty(_FullName)) { Pa.Persons.FullName = _FullName; }
            if (!string.IsNullOrEmpty(_Mother)) { Pa.Persons.Mother = _Mother; }
            if (!string.IsNullOrEmpty(_Father)) { Pa.Persons.Father = _Father; }
            if (!string.IsNullOrEmpty(_Phone1)) { Pa.Persons.Phone1 = _Phone1; }
            if (!string.IsNullOrEmpty(_Phone2)) { Pa.Persons.Phone2 = _Phone2; }
            if (!string.IsNullOrEmpty(_NationalityNumber)) { Pa.Persons.NationalityNumber = _NationalityNumber; }
            if (!string.IsNullOrEmpty(_Photo1)) { Pa.Persons.Photo1 = _Photo1; }
            if (!string.IsNullOrEmpty(_Photo2)) { Pa.Persons.Photo1 = _Photo2; }
            if (!string.IsNullOrEmpty(_Gender)) { Pa.Persons.Gender = _Gender; }
            if (!string.IsNullOrEmpty(_Color)) { Pa.Persons.Color = _Color; }
            if (!string.IsNullOrEmpty(_Adress)) { Pa.Persons.Adress = _Adress; }
            if (!string.IsNullOrEmpty(_PlaceBirth)) { Pa.Persons.PlaceBirth = _PlaceBirth; }
            if (!string.IsNullOrEmpty(_GeneralInfo)) { Pa.Persons.GeneralInfo = _GeneralInfo; }
            if (!string.IsNullOrEmpty(_Email)) { Pa.Persons.Email = _Email; }
            if (!string.IsNullOrEmpty(_PassportNumber)) { Pa.Persons.PassportNumber = _PassportNumber; }

            if (!string.IsNullOrEmpty(_NickName)) { Pa.Persons.NickName = _NickName; }
            if (!string.IsNullOrEmpty(_SurName)) { Pa.Persons.SurName = _SurName; }
            if (!string.IsNullOrEmpty(_CountryState)) { Pa.Persons.CountryState = _CountryState; }

            if (_ChildCount != null) { Pa.Persons.ChildCount = _ChildCount; }
            if (_MinChildAge != null) { Pa.Persons.MinChildAge = _MinChildAge; }
            if (_MaxChildAge != null) { Pa.Persons.MaxChildAge = _MaxChildAge; }

            if (!string.IsNullOrEmpty(_Education)) { Pa.Persons.Education = _Education; }
            if (!string.IsNullOrEmpty(_EducationBranch)) { Pa.Persons.EducationBranch = _EducationBranch; }
            if (!string.IsNullOrEmpty(_WorkType)) { Pa.Persons.WorkType = _WorkType; }
            if (!string.IsNullOrEmpty(_Languages)) { Pa.Persons.Languages = _Languages; }
            if (!string.IsNullOrEmpty(_LivingLevel)) { Pa.Persons.LivingLevel = _LivingLevel; }
            if (!string.IsNullOrEmpty(_Theams)) { Pa.Persons.Theams = _Theams; }
            if (!string.IsNullOrEmpty(_Hobbies)) { Pa.Persons.Hobbies = _Hobbies; }
            if (!string.IsNullOrEmpty(_Culture)) { Pa.Persons.Culture = _Culture; }
            if (!string.IsNullOrEmpty(_CultureLevel)) { Pa.Persons.CultureLevel = _CultureLevel; }


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

        public static PersonViewModel Find(int Id)
        {
            return new PersonViewModel(new PersonDAL(Id));
        }


        #endregion
        #region Business Function
        public static List<PersonViewModel> GetPersonList()
        {
            List<PersonViewModel> List = new List<PersonViewModel>();
            PersonDAL.GetPersonsList().ForEach(r => List.Add(new PersonViewModel(r)));
            return List;
        }
        public static List<PersonViewModel> GetPersonList(int Country, int Ages, string Education, int Nationality, string Gender)
        {
            List<PersonViewModel> List = new List<PersonViewModel>();
            PersonDAL.GetPersonsList(Country, Ages, Education, Nationality, Gender).ForEach(r => List.Add(new PersonViewModel(r)));
            return List;
        }

        public static IEnumerable GetPersonsComboList()
        {
            return PersonDAL.GetPersonsComboList();
        }
        /// <summary>
        /// GetPerson By User Id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static PersonViewModel GetPersonByUser(int userId)
        {
            PersonDAL P = PersonDAL.GetPersonByUser(userId);

            PersonViewModel Person = new PersonViewModel(P);

            return Person;
        }


        #endregion

        #region Search Parameters

        private string _Residence_Country;

        public string Residence_Country
        {
            get { return _Residence_Country; }
            set { _Residence_Country = value; }
        }


        #endregion

        #region Customize Visible Fields
        private bool _FullName_IsHidden;
        private bool _NickName_IsHidden;
        private bool _SurName_IsHidden;
        private bool _Phone1_IsHidden;
        private bool _Phone2_IsHidden;
        private bool _Email_IsHidden;
        private bool _Adress_IsHidden;
        private bool _Theams_IsHidden;
        private bool _Photo1_IsHidden;
        private bool _Photo2_IsHidden;
        private bool _Color_IsHidden;
        private bool _Weight_IsHidden;
        private bool _height_IsHidden;
       
        
        public bool FullName_IsHidden
        {
            get { return _FullName_IsHidden; }
            set { _FullName_IsHidden = value; }
        }
        public bool NickName_IsHidden
        {
            get { return _NickName_IsHidden; }
            set { _NickName_IsHidden = value; }
        }

        public bool SurName_IsHidden
        {
            get { return _SurName_IsHidden; }
            set { _SurName_IsHidden = value; }
        }

        public bool Phone1_IsHidden
        {
            get { return _Phone1_IsHidden; }
            set { _Phone1_IsHidden = value; }
        }

        public bool Phone2_IsHidden
        {
            get { return _Phone2_IsHidden; }
            set { _Phone2_IsHidden = value; }
        }
        public bool Email_IsHidden
        {
            get { return _Email_IsHidden; }
            set { _Email_IsHidden = value; }
        }

        public bool Adress_IsHidden
        {
            get { return _Adress_IsHidden; }
            set { _Adress_IsHidden = value; }
        }

        public bool Theams_IsHidden
        {
            get { return _Theams_IsHidden; }
            set { _Theams_IsHidden = value; }
        }

     
        public bool Photo1_IsHidden
        {
            get { return _Photo1_IsHidden; }
            set { _Photo1_IsHidden = value; }
        }
        public bool Photo2_IsHidden
        {
            get { return _Photo2_IsHidden; }
            set { _Photo2_IsHidden = value; }
        }

        public bool Color_IsHidden
        {
            get { return _Color_IsHidden; }
            set { _Color_IsHidden = value; }
        }

        public bool Weight_IsHidden
        {
            get { return _Weight_IsHidden; }
            set { _Weight_IsHidden = value; }
        }

        public bool Height_IsHidden
        {
            get { return _height_IsHidden; }
            set { _height_IsHidden = value; }
        }
        
        
        public void SaveCustomizeFlds()
        {

            SaveCustomizeFld(this._FullName_IsHidden, "FullName");
            SaveCustomizeFld(this._NickName_IsHidden, "NickName");
            SaveCustomizeFld(this._SurName_IsHidden, "SurName");
            SaveCustomizeFld(this._Phone1_IsHidden, "Phone1");
            SaveCustomizeFld(this._Phone2_IsHidden, "Phone2");
            SaveCustomizeFld(this._Email_IsHidden, "Email");
            SaveCustomizeFld(this._Adress_IsHidden, "Adress");
            SaveCustomizeFld(this._Theams_IsHidden, "Theams");
            SaveCustomizeFld(this._Photo1_IsHidden, "Photo1");
            SaveCustomizeFld(this._Photo2_IsHidden, "Photo2");
            SaveCustomizeFld(this._Color_IsHidden,"Color");
            SaveCustomizeFld(this._Weight_IsHidden, "Weight");
            SaveCustomizeFld(this._height_IsHidden, "Height");

        }
        private void SaveCustomizeFld(bool FldHideValue, string FldName)
        {
            using (var db = new SOKNAEntities())
            {
                //Hide the field
                if (FldHideValue)
                {
                    if (!db.PersonHiddenFlds.Any(h => h.FieldName == FldName && h.Person_Id == this.Id))
                    {
                        PersonHiddenFlds p = new PersonHiddenFlds();
                        p.Person_Id = this.Id;
                        p.FieldName = FldName;
                        db.PersonHiddenFlds.Add(p);
                    }
                }
                //Show the field
                else
                {
                    if (db.PersonHiddenFlds.Any(h => h.FieldName == FldName && h.Person_Id == this.Id))
                    {
                        var fldHiddenItem = (from h in db.PersonHiddenFlds
                                             where (h.FieldName == FldName && h.Person_Id == this.Id)
                                             select h).First();
                        if (fldHiddenItem != null)
                        {
                            db.PersonHiddenFlds.Remove(fldHiddenItem);
                        }
                    }
                }
                db.SaveChanges();
            }

        }
        private void ReadCustomizeFld(int personID)
        {
            using (var db = new SOKNAEntities())
            {
                _FullName_IsHidden = (db.PersonHiddenFlds.Any(h => h.Person_Id == personID && h.FieldName == "FullName"));
                _NickName_IsHidden = (db.PersonHiddenFlds.Any(h => h.Person_Id == personID && h.FieldName == "NickName"));
                _SurName_IsHidden = (db.PersonHiddenFlds.Any(h => h.Person_Id == personID && h.FieldName == "SurName"));
                _Phone1_IsHidden = (db.PersonHiddenFlds.Any(h => h.Person_Id == personID && h.FieldName == "Phone1"));
                _Phone2_IsHidden = (db.PersonHiddenFlds.Any(h => h.Person_Id == personID && h.FieldName == "Phone2"));
                _Email_IsHidden = (db.PersonHiddenFlds.Any(h => h.Person_Id == personID && h.FieldName == "Email"));
                _Adress_IsHidden = (db.PersonHiddenFlds.Any(h => h.Person_Id == personID && h.FieldName == "Adress"));
                _Theams_IsHidden = (db.PersonHiddenFlds.Any(h => h.Person_Id == personID && h.FieldName == "Theams"));
                _Photo1_IsHidden = (db.PersonHiddenFlds.Any(h => h.Person_Id == personID && h.FieldName == "Photo1"));
                _Photo2_IsHidden = (db.PersonHiddenFlds.Any(h => h.Person_Id == personID && h.FieldName == "Photo2"));
                _Color_IsHidden = (db.PersonHiddenFlds.Any(h => h.Person_Id == personID && h.FieldName == "Color"));
                _Weight_IsHidden = (db.PersonHiddenFlds.Any(h => h.Person_Id == personID && h.FieldName == "Weight"));
                _height_IsHidden = (db.PersonHiddenFlds.Any(h => h.Person_Id == personID && h.FieldName == "Height"));
                

            }
        }


    }

    #endregion
}
