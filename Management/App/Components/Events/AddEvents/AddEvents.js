import moment from 'moment';
export default {
    name: 'AddEvents',

    created() {
        this.getyearName();
        this.getTeatcherName();
    },
    components: {
    },
    data() {
        return {


            year: [],
            

            subjects: [],
            teachers: [],


            form: {
                yearId: '',

                TeacherId: '',
                SubjectId: '',
                Name: '',
                Discreptions: '',
            },
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
        back() {
            this.$parent.state = 0;
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

            this.$blockUI.Start();
            this.$http.getSubject(this.form.yearId)
                .then(response => {

                    this.$blockUI.Stop();
                    this.subjects = response.data.subject;
                })
                .catch((err) => {
                    this.$blockUI.Stop();
                    console.error(err);
                });
        },

        getTeatcherName() {

            this.$blockUI.Start();
            this.$http.getTeatcherName()
                .then(response => {

                    this.$blockUI.Stop();
                    this.teachers = response.data.teacher;
                })
                .catch((err) => {
                    this.$blockUI.Stop();
                    console.error(err);
                });
        },




        resetForm(formName) {
            this.$refs[formName].resetFields();
        },

        submitForm(formName) {
            this.$refs[formName].validate((valid) => {
                if (valid) {
                    this.addEvent(formName);
                } else {
                    console.log('error submit!!');
                    return false;
                }
            });


        },


        addEvent(formName) {
            this.$blockUI.Start();
            this.$http.addEvent(this.form)
                .then(response => {
                    //this.$parent.state = 0;
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
        }
    }
}
