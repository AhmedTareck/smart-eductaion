import moment from 'moment';
export default {
    name: 'AddSubjects',

    created() {
        //this.form.id = this.$parent.yearSelected;
        this.getyearName();
    },
    components: {
    },
    data() {
        return {
            year: [],

            form: {
                id: '',
                name: '',
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

        resetForm(formName) {
            this.$refs[formName].resetFields();
        },

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


        addSubject(formName) {
            this.$http.addSubject(this.form)
                .then(response => {
                    //this.$parent.state = 0;
                    this.$message({
                        type: 'info',
                        message: response.data
                    });
                    //this.$parent.GetSubjectInfo();
                    //this.$parent.state = 0;
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
