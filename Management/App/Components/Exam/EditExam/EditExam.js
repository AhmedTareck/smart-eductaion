
﻿import moment from 'moment';
export default {
    name: 'EditExam',
    
    created() { 
        this.selectedExam = this.$parent.selectedExams;

    },
    components: {
    },
    data() {
        return {

            
            selectedExam: {
                eventId: '',
                yearId: '',
                name: '',
                disctiption: '',
                fullMarck: '',
                examDate: '',
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

        back() {
            this.$parent.state = 0;
        },

        submitForm(formName) {
            this.$refs[formName].validate((valid) => {
                if (valid) {
                    this.editExam();
                } else {
                    console.log('error submit!!');
                    return false;
                }
            });


        },


        editExam() {
            this.$http.editExam(this.selectedExam)
                .then(response => {
                    this.$message({
                        type: 'info',
                        message: response.data
                    });
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

        
       
    }    
}
