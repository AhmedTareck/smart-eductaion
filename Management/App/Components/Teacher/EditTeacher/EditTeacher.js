export default {
    name: 'EditTeacher',
    created() {
        this.x = this.$parent.EditUsersObj;
        this.ruleForm.FullName = this.$parent.EditUsersObj.name;
        this.ruleForm.LoginName = this.$parent.EditUsersObj.loginName;
        this.ruleForm.Phone = this.$parent.EditUsersObj.phone;
        this.ruleForm.Email = this.$parent.EditUsersObj.email;
        this.ruleForm.Gender = this.$parent.EditUsersObj.gender;
        this.ruleForm.DateOfBirth = this.$parent.EditUsersObj.birthDate;
        this.ruleForm.UserId = this.$parent.EditUsersObj.userId;
     
        this.ruleForm.UserType = "" + this.$parent.EditUsersObj.userType;
      
  

    },
    data() {

        return {
            pageNo: 1,
            pageSize: 10,
            pages: 0,
            isFromSelect: true,
            Users: [],
            Permissions: [],
            state: 0,

            x:[],

            PermissionModale: [],
            ruleForm: {
                UserId: '',
                LoginName: '',
               
                FullName: '',
                UserType: '',
                Email: '',
                Gender: '',
                Phone: '',
                DateOfBirth: '',
                Status: 0,
                BranchId: 1,
          




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

        };
    },
    methods: {
        Back() {
            this.$parent.state = 0;
        },

        validPhone: function (Phone) {

            var mobileRegex = /^09[1|2|3|4|5][0-9]{7}$/i;

            return mobileRegex.test(Phone);
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

        Edit(formName) {
            this.$refs[formName].validate((valid) => {
                if (valid) {
                    this.$http.EditUser(this.ruleForm)
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
