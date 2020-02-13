﻿import CryptoJS from 'crypto-js';
export default {
    name: 'EditUsersProfile',    
    created() {

        this.SECRET_KEY = 'P@SSWORDTAMEME';

        try {
            this.loginDetails = this.decrypt(sessionStorage.getItem('currentUser'));
        } catch (error) {
            window.location.href = '/Security/Login';
        }
        if (this.loginDetails != null) {
            this.loginDetails = JSON.parse(this.loginDetails);
            this.ruleForm.FullName = this.loginDetails.fullName;
            this.ruleForm.Phone = this.loginDetails.phone;
            this.ruleForm.LoginName = this.loginDetails.loginName;
            this.ruleForm.Email = this.loginDetails.email;
            this.ruleForm.Gender = this.loginDetails.gender;
            this.ruleForm.DateOfBirth = this.loginDetails.birthDate;
            this.ruleForm.UserType = this.loginDetails.userType;
         
        } else {
            window.location.href = '/Security/Login';
        }
      
     
    },
    data() {  
       
        return {
            form: {
                
                Status: 0,
                OfficeName: '',
                AllData: [],
                loginDetails: null,
                photo:[]

            }, 
            ruleForm: {
             
                LoginName: '',
               
                FullName: '',
                UserType: 1,
                Email: '',
                Gender: '',
                Phone: '',
                DateOfBirth: '',
                Status: 0,
            },
            rules: {
                DateOfBirth: [
                    { required: true, message: 'الرجاء إدخال تاريخ الميلاد', trigger: 'blur' }
                ],
              
             
                UserType: [
                    { required: true, message: 'الرجاء اختيار  الصلاحيه', trigger: 'blur' }
                ],
                FullName: [
                    { required: true, message: 'الرجاء إدخال الاسم التلاثي', trigger: 'blur' },
                    { required: true, message: /^[\u0621-\u064A\u0660-\u0669 ]+$/, trigger: 'blur' }
                ],
                LoginName: [
                    { required: true, message: 'الرجاء إدخال اسم الدخول', trigger: 'blur' },
                    { required: true, pattern: /^[A-Za-z]{0,40}$/, message: 'الرجاء إدخال اسم الدخول بطريقه صحيحه', trigger: 'blur' }
                ],
                Phone: [
                    { required: true, message: 'الرجاء إدخال رقم الهاتف', trigger: 'blur' },
                    { min: 9, max: 10, message: 'الرجاء إدخال رقم الهاتف  بطريقه صحيحه', trigger: 'blur' }
                ],


                Email: [
                    { required: true, message: 'الرجاء إدخال البريد الإلكتروني', trigger: 'blur' },
                    { required: true, pattern: /\S+@\S+\.\S+/, message: 'الرجاء إدخال البريد الإلكتروني بطريقه صحيحه', trigger: 'blur' }
                ],
                Gender: [
                    { required: true, message: 'الرجاء اختيار الجنس', trigger: 'change' }

                ],

            }
           
            
        }
    },
    methods: {
        hash: function hash(key) {
            key = CryptoJS.SHA256(key, SECRET_KEY);

            return key.toString();
        },
        encrypt: function encrypt(data) {
            var dataSet = CryptoJS.AES.encrypt(data.toString(), this.SECRET_KEY);
            dataSet = dataSet.toString();
            return dataSet;
        },
        decrypt: function decrypt(data) {
            var dataSet = CryptoJS.AES.decrypt(data, this.SECRET_KEY);
            var plaintext = dataSet.toString(CryptoJS.enc.Utf8);
            dataSet = plaintext.toString(CryptoJS.enc.Utf8);
            return dataSet;
        },
        validPhone: function (Phone) {

            var mobileRegex = /^09[1|2|3|4|5][0-9]{7}$/i;

            return mobileRegex.test(Phone);
        },
        FileChanged(e) {
            var files = e.target.files;

            if (files.length <= 0) {
                return;
            }

            if (files[0].type !== 'image/jpeg' && files[0].type !== 'image/png') {
                this.$message({
                    type: 'error',
                    message: 'عفوا يجب انت تكون الصورة من نوع JPG ,PNG'
                });
                this.photo = null;
                return;
            }

            var $this = this;

            var reader = new FileReader();
            reader.onload = function () {
                $this.photo = reader.result;
                $this.UploadImage();
            };
            reader.onerror = function (error) {
                $this.photo = null;
            };
            reader.readAsDataURL(files[0]);
        },

        UploadImage() {
            console.log(this.photo);
            console.log(this.loginDetails.userId);
            this.$blockUI.Start();
            var obj = {
                Photo: this.photo,
                UserId: this.loginDetails.userId
            };
            this.$http.UploadImage(obj)
                .then(response => {
                    this.$blockUI.Stop();
                    this.$message({
                        type: 'success',
                        dangerouslyUseHTMLString: true,
                        duration: 5000,
                        message: '<strong>' + response.data + '</strong>'
                    });
                    setTimeout(() =>
                        window.location.href = '/EditUsersProfile'
                        , 500);

                })
                .catch((err) => {
                    this.$blockUI.Stop();
                    console.error(err);
                    this.pages = 0;
                });
        },
        validEmail: function (email) {
            var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            return re.test(email);
        },
        validLoginName: function (LoginName) {
            var login = /^[a-zA-Z]{0,40}$/;
            return login.test(LoginName);
        },


        Save(formName) {
            this.$refs[formName].validate((valid) => {
                if (valid) {
                    this.$http.EditUsersProfile(this.ruleForm)
                        .then(response => {

                            this.loginDetails.email = this.ruleForm.Email;
                            this.loginDetails.phone = this.ruleForm.Phone;

                            this.loginDetails.fullName=this.ruleForm.FullName;
                            this.loginDetails.phone=this.ruleForm.Phone;
                            this.loginDetails.loginName=this.ruleForm.LoginName;
                      
                           this.loginDetails.gender =this.ruleForm.Gender;
                            this.loginDetails.dateOfBirth = this.ruleForm.DateOfBirth;
                            sessionStorage.setItem('currentUser', JSON.stringify(this.loginDetails));
                

          
                            this.$message({
                                type: 'success',
                                dangerouslyUseHTMLString: true,
                                duration: 5000,
                                message: '<strong>' + response.data + '</strong>'
                            });
                        })
                        .catch((err) => {
                            this.$message({
                                type: 'error',
                                dangerouslyUseHTMLString: true,
                                duration: 5000,
                                message: '<strong>' + err.response.data + '</strong>'
                            });
                        });
                } else {
                    console.log('error submit!!');
                    return false;
                }
            });


        },

    }
}
