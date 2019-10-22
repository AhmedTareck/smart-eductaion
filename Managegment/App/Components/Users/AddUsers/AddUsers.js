export default {
    name: 'AddUser',    
    created() 
    {
        this.BranchId = this.$parent.BrancheModel;
     
    },
    
    data() {
        return {
            pageNo: 1,
            pageSize: 10,
            pages: 0,

            ruleForm: {
                UserId:0,
                LoginName: '',
                Password: '',
                FullName: '',
                UserType: '',
                Email: '',
                Gender: '',
                Phone:'',
                DateOfBirth: '',
                Status: 0, 
                BranchId:1,
             
                
                
              
            },      
                  ConfimPassword: '', 
       
            rules: {
                DateOfBirth: [
                    { required: true, message: 'الرجاء إدخال تاريخ الميلاد', trigger: 'blur', type: 'date'}
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
                Password: [
                    { required: true, message: 'الرجاء إدخال كلمة المرور', trigger: 'blur' },
                    { required: true, pattern: /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]){8,}.*$/, message: 'الرجاء إدخال كلمة المرور  بطريقه صحيحه', trigger: 'blur' }
                ],

                Email: [
                    { required: true, message: 'الرجاء إدخال البريد الإلكتروني', trigger: 'blur' },
                    { required: true, pattern: /\S+@\S+\.\S+/, message: 'الرجاء إدخال البريد الإلكتروني بطريقه صحيحه', trigger: 'blur' }
                ],
                Gender: [
                    { required: true, message: 'الرجاء اختيار الجنس', trigger: 'change' }
                   
                ],
             
            }

        };


    },
    methods: {
        
        Back() {
            this.$parent.UserType = 0;
            this.$parent.GetUsers();
            //this.$parent.NID = '';
            //this.$parent.PermissionModale = '';
            this.$parent.state = 0;       
        },
   

        validEmail: function (email) {
            var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            return re.test(email);
        },
        validLoginName: function (LoginName) {
            var login = /^[a-zA-Z]{0,40}$/;
            return login.test(LoginName);
        },
        validFullName: function (FullName) {
            var loginArabic = /^[\u0621-\u064A\u0660-\u0669 ]+$/;
            return loginArabic.test(FullName);
        },

       validPassword: function (Password) {
          
           var PasswordT = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]){8,}.*$/;

            return PasswordT.test(Password);
        },
        validPhone: function (Phone) {

            var mobileRegex = /^09[1|2|3|4|5][0-9]{7}$/i;

            return mobileRegex.test(Phone);
        },

        Save(formName) {   
              
            this.ruleForm.BranchId = this.$parent.BrancheModel;
       
            this.$refs[formName].validate((valid) => {
                if (valid) {
                    this.ruleForm.BranchLevel = this.$parent.permissionModale;
                    if (this.ruleForm.Password != this.ConfimPassword) {
                        this.$message({
                            type: 'success',
                            dangerouslyUseHTMLString: true,
                            duration: 5000,
                            message: '<strong>' + 'الرجاء تطابق كلمة المرور' + '</strong>'
                        });
                        return;
                    }
                    this.$http.AddUser(this.ruleForm)
                        .then(response => {
                            this.$parent.state = 0;
                            this.$parent.GetUsers(this.pageNo);
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


        }




    }    
}
