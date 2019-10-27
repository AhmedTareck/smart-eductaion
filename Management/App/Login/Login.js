import CryptoJS from 'crypto-js';


export default {
    name: 'login',
    created() {
        this.returnurl = location.pathname;
        this.SetRules();
        this.SECRET_KEY = 'P@SSWORDTAMEME';


    },
    data() {
        return {
            returnurl: '',
            form: {
                Password: null,
                Email: null
            },
            form2: {
                Email: null
            },
            SECRET_KEY:'',
            success: { confirmButtonText: 'OK', type: 'success', dangerouslyUseHTMLString: true, center: true },
            error: { confirmButtonText: 'OK', type: 'error', dangerouslyUseHTMLString: true, center: true },
            warning: { confirmButtonText: 'OK', type: 'warning', dangerouslyUseHTMLString: true, center: true },
            rules: {},
            forgetPassowrd: false,



        };
    },
    methods: {
        hash: function hash(key) {
            key = CryptoJS.SHA256(key, SECRET_KEY);

            return key.toString();
        },
        encrypt: function encrypt(data) {
            debugger;
            var dataSet = CryptoJS.AES.encrypt(JSON.stringify(data), this.SECRET_KEY);
            dataSet = dataSet.toString();
            return dataSet;
        },
        decrypt: function decrypt(data) {
            data = CryptoJS.AES.decrypt(data, SECRET_KEY);
            data = data.toString(CryptoJS.enc.Utf8);
            return data;
        },
        //Login() {
        //    this.$emit('authenticated');
        //},

        login() {
            if (!this.form.Email) {
                this.$message({
                    type: 'error',
                    dangerouslyUseHTMLString: true,
                    duration: 5000,
                    message: '<strong>' + 'الرجاء إدخال لبريد الإلكتروني' + '</strong>'
                });
                return;
            }
            if (!this.form.Password) {


                this.$message({
                    type: 'error',
                    dangerouslyUseHTMLString: true,
                    duration: 5000,
                    message: '<strong>' + 'الرجاء إدخال الرقم السري' + '</strong>'
                });
                
                return;
            }

            let $blockUI = this.$loading({
                fullscreen: true,
                text: 'loading ...'
            });
            this.$http.loginUserAccount(this.form)
                .then(response => {
                    $blockUI.close();
                    //this.secureStorage.setItem('currentUser', response.data);
                    sessionStorage.setItem('currentUser', this.encrypt(response.data));
                    window.location.href = '/';
                })
                .catch((error) => {
                    $blockUI.close()
               

                    this.$message({
                        type: 'error',
                        dangerouslyUseHTMLString: true,
                        duration: 5000,
                        message: '<strong>' + error.response.data  + '</strong>'
                    });
                    if (error.response.status == 400) {
                        this.$message({
                            type: 'warning',
                            dangerouslyUseHTMLString: true,
                            duration: 5000,
                            message: '<strong>' + error.response.data + '</strong>'
                        });
                      
                    } else if (error.response.status == 404) {
                        this.$message({
                            type: 'warning',
                            dangerouslyUseHTMLString: true,
                            duration: 5000,
                            message: '<strong>' + error.response.data + '</strong>'
                        });

                    } else {
                        console.log(error.response);
                    }
                });
        },


        ResetPassword(formName) {
            this.$refs[formName].validate((valid) => {
                if (valid) {
                    let $blockUI = this.$loading({
                        fullscreen: true,
                        text: 'loading ...'
                    });
                    this.$http.ResetPassword(this.form2.Email.trim())
                        .then(response => {
                            $blockUI.close()
                            this.form2.Email = null;
                            this.forgetPassowrd = false;
                            this.$alert('<h4>' + response.data + '</h4>', '', this.success);
                        })
                        .catch((error) => {
                            $blockUI.close()

                            if (error.response.status == 400) {
                                this.$alert('<h4>' + error.response.data + '</h4>', '', this.warning);
                            } else if (error.response.status == 404) {
                                this.$alert('<h4>' + error.response.data + '</h4>', '', this.error);
                            } else {
                                console.log(error.response);
                            }
                        });
                } else {
                    console.log("form not complete");
                    return false;
                }
            });
        },
        SetRules() {

            this.rules = {
                Email: [
                    { required: true, message: 'Please input your Email', trigger: 'blur' },
                    { type: 'email', message: 'Please input correct email address', trigger: ['blur', 'change'] }
                ],
                Password: [
                    { required: true, message: 'Please input your Password', trigger: 'blur' }
                ],
            }
        },
    }
}
