import moment from 'moment';
export default {
    name: 'SignUp',
    components: {

    },
    created() {    
        this.Students();
        var loginDetails = localStorage.getItem('currentUser');
        if (loginDetails !== null && loginDetails !== "null") {
            this.loginDetails = JSON.parse(loginDetails);
            this.GetInbox();
            this.GetSentMessage();
        } else {
            window.location.href = '/Login';
        }       
    },
    filters: {
        moment: function (date) {
            if (date === null) {
                return 'فارغ';
            }
            // return moment(date).format('MMMM Do YYYY, h:mm:ss a');
            return moment(date).format('HH:MM:SS');
        }
    },
    data() {
        return {
            Show:1,
            pageNo: 1,
            pageSize: 10,
            pages: 0, 
            ruleForm: {
                SentByStudent:'',
                RecivedByStudent: '',
                Subject: '',
                Payload:''
            },
            rules: {
                //RecivedByStudent
                RecivedByStudent: [
                    { required: true, message: 'الرجاء إختيار اسم الطالب ', trigger: 'change' }
                ],
                Subject: [
                    { required: true, message: 'الرجاء إدخال عتوان الرسالة', trigger: 'blur' },
                    { min: 2, max: 50, message: 'يجب ان يكون طول العنوان من 2 الي 50 الحرف', trigger: 'blur' }
                ],
                Payload: [
                    { required: true, message: 'الرجاء إدخال الرسـالة', trigger: 'blur' },
                    { min: 2, max: 600, message: 'يجب ان يكون طول الرسالة من 10 الي 600 الحرف', trigger: 'blur' }
                ]
            },



            loginDetails: null,
            gridData: [{
                date: '2016-05-02',
                name: 'John Smith',
                address: 'No.1518,  Jinshajiang Road, Putuo District'
            }, {
                date: '2016-05-04',
                name: 'John Smith',
                address: 'No.1518,  Jinshajiang Road, Putuo District'
            }, {
                date: '2016-05-01',
                name: 'John Smith',
                address: 'No.1518,  Jinshajiang Road, Putuo District'
            }, {
                date: '2016-05-03',
                name: 'John Smith',
                address: 'No.1518,  Jinshajiang Road, Putuo District'
            }],
            dialogTableVisible: false,
            dialogFormVisible: false,
            form: {
                name: '',
                region: '',
                date1: '',
                date2: '',
                delivery: false,
                type: [],
                resource: '',
                desc: ''
            },
            formLabelWidth: '120px',
            success: { confirmButtonText: 'OK', type: 'success', dangerouslyUseHTMLString: true, center: true },
            error: { confirmButtonText: 'OK', type: 'error', dangerouslyUseHTMLString: true, center: true },
            warning: { confirmButtonText: 'OK', type: 'warning', dangerouslyUseHTMLString: true, center: true },
            Inbox: [],
            Sent:[]
        };
    },
    methods: {
        changepage(id) {
            this.Show = id;
        },


        //GetInbox
        GetInbox(pageNo) {
            this.pageNo = pageNo;
            if (this.pageNo === undefined) {
                this.pageNo = 1;
            }
            this.$blockUI.Start();
            this.$http.GetInbox(this.pageNo, this.pageSize)
                .then(response => {
                    this.$blockUI.Stop();
                    this.Inbox = response.data.inbox;
                   
                })
                .catch((err) => {
                    this.$blockUI.Stop();
                    console.error(err);
                });
        },

        //GetSentMessage
        GetSentMessage(pageNo) {
            this.pageNo = pageNo;
            if (this.pageNo === undefined) {
                this.pageNo = 1;
            }
            this.$blockUI.Start();
            this.$http.GetSentMessage(this.pageNo, this.pageSize)
                .then(response => {
                    this.$blockUI.Stop();
                    this.Sent = response.data.sentMessage;
                })
                .catch((err) => {
                    this.$blockUI.Stop();
                    console.error(err);
                });
        },


        submitForm(formName) {
            this.$refs[formName].validate((valid) => {
                if (valid) {

                    this.$blockUI.Start();
                    this.$http.SentMessage(this.ruleForm)
                        .then(response => {
                            this.$blockUI.Stop();
                            // this.$alert('<h4>' + 'تم تسجيل بياناتك بنجاح وارسال بريد التحقق بنجاح الرجاء فتح بريدك الإلكتروني ' + '</h4>', '', this.success);

                            this.$alert('<h4>' + response.data + '</h4>', '', this.success);
                            this.$refs[formName].resetFields();
                            this.dialogTableVisible = false;
                            this.dialogFormVisible = false;
                            this.GetInbox();
                            this.GetSentMessage();
                        })
                        .catch((error) => {

                            this.$blockUI.Stop();
                            console.log(error.response.status);
                            if (error.response.status === 400) {
                                this.$alert('<h4>' + error.response.data + '</h4>', '', this.warning);
                            }
                            if (error.response.status === 404) {
                                this.$alert('<h4>' + error.response.data + '</h4>', '', this.error);
                            } else {
                                this.$alert('<h4>' + error.response.data + '</h4>', '', this.error);
                            }
                        });
                } else {
                    console.log('error submit!!');
                    return false;
                }
            });
        },

        resetForm(formName) {
            this.$refs[formName].resetFields();
        },

        Students() {
            
            this.$http.GetStudents()
                .then(response => {
                  
                    this.Students = response.data.students;
                })
                .catch((err) => {
                   
                    console.error(err);
                });
        },


    }    
}
