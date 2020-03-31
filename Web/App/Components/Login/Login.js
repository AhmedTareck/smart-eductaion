

export default {
    name: 'Login',
    components: {
      
    },
    created() {        
    },
    data() {
        return {
            form: {
                Password: null,
                Email: null
            },


        };
    },
    methods: {

        login() {
            if (!this.form.Email) {
                this.$message({
                    type: 'error',
                    dangerouslyUseHTMLString: true,
                    duration: 5000,
                    message: '<strong><b>' + 'الرجاء إدخال لبريد الإلكتروني' + '</b></strong>'
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
                    sessionStorage.setItem('currentUser', (JSON.stringify(response.data)));
                    window.location.href = '/';
                })
                .catch((error) => {
                    $blockUI.close()


                    this.$message({
                        type: 'error',
                        dangerouslyUseHTMLString: true,
                        duration: 5000,
                        message: '<strong>' + error.response.data + '</strong>'
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


    }    
}
