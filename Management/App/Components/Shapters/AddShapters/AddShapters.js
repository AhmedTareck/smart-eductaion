import moment from 'moment';
export default {
    name: 'AddShapters',

    created() {
        //this.form.id = this.$parent.yearSelected;
        //this.form.SubjectId = this.$parent.SubjectSelected;

        this.getyearName();
        this.GetSubjectInfo();
    },
    components: {
    },
    data() {
        return {
            form: {
                id: '',
                name: '',
                SubjectId: '',
                ShapterNumber: '',
                EventId: '',
                yearId:'',
            },

            year: [],

            SubjectName: [],

            EventName: [],
        };
    },

    filters: {
        moment: function (date) {
            if (date === null) {
                return 'فارغ';
            }
            return moment(date).format('MMMM Do YYYY');
        }
    },


    methods: {
        //back() {
        //    this.$parent.state = 0;
        //},

        submitForm(formName) {
            this.$refs[formName].validate((valid) => {
                if (valid) {
                    this.addSubject(formName);
                } else {
                    console.log('error submit!!');
                    return false;
                }
            });


        },

        resetForm(formName) {
            this.$refs[formName].resetFields();
        },


        addSubject(formName) {
            this.$blockUI.Start();
            this.$http.addShapter(this.form)
                .then(response => {
                    this.$message({
                        type: 'info',
                        message: response.data
                    });
                    this.resetForm(formName);
                    this.$blockUI.Stop();
                })
                .catch((err) => {
                    this.$blockUI.Stop();
                    this.$message({
                        type: 'error',
                        message: err.response.data
                    });
                });
        },

        getyearName() {

            this.$blockUI.Start();
            this.$http.getyearName()
                .then(response => {

                    this.$blockUI.Stop();
                    this.year = response.data.years;
                })
                .catch((err) => {
                    this.$blockUI.Stop();
                    console.error(err);
                });
        },

        getSubject() {
            //this.SubjectName = [];
            //this.form.SubjectId= '';
            //this.getShpater();
            this.$blockUI.Start();
            this.$http.getSubject(this.form.yearId)

                .then(response => {

                    this.$blockUI.Stop();
                    this.SubjectName = response.data.subject;
                })
                .catch((err) => {
                    this.$blockUI.Stop();
                    console.error(err);
                });
        },

        getEventName() {
            //this.SubjectName = [];
            //this.form.SubjectId = '';
            //this.getShpater();
            this.$blockUI.Start();
            this.$http.getEventName(this.form.SubjectId)

                .then(response => {

                    this.$blockUI.Stop();
                    this.EventName = response.data.eventinfo;
                })
                .catch((err) => {
                    this.$blockUI.Stop();
                    console.error(err);
                });
        },
    }
}
