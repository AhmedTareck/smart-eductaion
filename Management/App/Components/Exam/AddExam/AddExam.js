
import moment from 'moment';
export default {
    name: 'AddExam',

    created() {
        this.GetYears();
    },
    components: {
    },
    data() {
        return {

            Years: [],

            Events: [],


            selectedExams: {
                eventId: '',
                yearId:'',
                name: '',
                disctiption: '',
                fullMarck: '',
                examDate:'',

            },
        };
    },

    filters: {
        moment: function (date) {
            if (date === null) {
                return 'فارغ';
            }
            // return moment(date).format('MMMM Do YYYY, h:mm:ss a');
            return moment(date).format('MMMM Do YYYY');
        }
    },


    methods: {

        submitForm(formName) {
            this.$refs[formName].validate((valid) => {
                if (valid) {
                    this.AddExam(formName);
                } else {
                    console.log('error submit!!');
                    return false;
                }
            });


        },

        GetYears() {
            this.$blockUI.Start();
            this.$http.GetYears()
                .then(response => {

                    this.$blockUI.Stop();
                    this.Years = response.data.years;
                })
                .catch((err) => {
                    this.$blockUI.Stop();
                    console.error(err);
                });
        },

        getEvents() {
            this.EventSelectd = '';
            this.$blockUI.Start();
            this.$http.GetEvents(this.selectedExams.yearId)

                .then(response => {

                    this.$blockUI.Stop();
                    this.Events = response.data.events;
                })
                .catch((err) => {
                    this.$blockUI.Stop();
                    console.error(err);
                });
        },

        AddExam(formName) {

            this.$http.AddExam(this.selectedExams)
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

        resetForm(formName) {
            this.$refs[formName].resetFields();
        },


    }
}
