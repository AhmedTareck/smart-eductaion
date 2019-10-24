export default {
    name: 'ChangePassword',
    created() {
     

    },
    data() {
        var validatePass = (rules, value, callback) => {
            if (value === '') {
                callback(new Error('الرجاء إدخال كلمة المرور الجديده'));
            } else {
                if (this.form.ConfimPassword !== '') {
                    this.$refs.form.validateField('ConfimPassword');
                }
                callback();
            }
        };
        var validatePass2 = (rules, value, callback) => {
            if (value === '') {
                callback(new Error('الرجاء إدخال تاكيد كلمة المرور الجديده'));
            } else if (value !== this.form.NewPassword) {
                callback(new Error('الرجاء التأكد من تطابق كلمة المرور'));
            } else {
                callback();
            }
        };
        return {

            form: {
                Password: '',
                NewPassword: '',
                ConfimPassword:''
            },

            rules: {
                Password: [
                    { required: true, message: 'الرجاء إدخال كلمة المرور الحاليه', trigger: 'blur' },
                    { required: true, pattern: /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]){8,}.*$/, message: 'الرجاء إدخال كلمة المرور  بطريقه صحيحه', trigger: 'blur' }
            
                ],
              
                NewPassword: [
                    { validator: validatePass, trigger: 'blur' },
                    { required: true, pattern: /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]){8,}.*$/, message: 'الرجاء إدخال كلمة المرور  بطريقه صحيحه', trigger: 'blur' }
                ],
                ConfimPassword: [
                    { validator: validatePass2, trigger: 'blur' },
                    { required: true, pattern: /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]){8,}.*$/, message: 'الرجاء إدخال كلمة المرور  بطريقه صحيحه', trigger: 'blur' }
                ],
            


        

            },
       

        };
    },
    methods: {
        validPassword: function (NewPassword) {

            var PasswordT = /^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]){8,}.*$/;

            return PasswordT.test(NewPassword);
        },
      
        Save(formName) {



            this.$refs[formName].validate((valid) => {
                if (valid) {

                    this.$http.ChangePassword(this.form)
                        .then(response => {
                            this.form.NewPassword = '';
                            this.form.ConfimPassword = '';
                            this.form.Password = '';
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
