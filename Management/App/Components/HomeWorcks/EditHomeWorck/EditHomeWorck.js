
﻿import moment from 'moment';
export default {
    name: 'EditHomeWorck',
    
    created() { 
        this.selectedHomeWorck = this.$parent.selectedHomeWorck;
    },
    components: {
    },
    data() {
        return {

            
            selectedHomeWorck: {
                eventId: '',
                yearId: '',
                name: '',
                lastDayDilavary: '',
                disctiption: '',
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
                    this.editHomeWorck();
                } else {
                    console.log('error submit!!');
                    return false;
                }
            });


        },


        editHomeWorck() {
            this.$http.editHomeWorck(this.selectedHomeWorck)
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
