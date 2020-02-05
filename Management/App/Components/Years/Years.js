﻿import moment from 'moment';
import EditYears from './EditYears/EditYears.vue';
export default {
    name: 'Years',
    
    created() { 
        this.GetYearsInfo();
    },
    components: {
        'EditYears': EditYears,
    },
    data() {
        return {

            state:0,

            pageNo: 1,
            pageSize: 5,
            pages: 0,

            Years:[],
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

        GetYearsInfo(pageNo) {
            this.pageNo = pageNo;
            if (this.pageNo === undefined) {
                this.pageNo = 1;
            }
            this.$blockUI.Start();
            this.$http.GetYearsInfo(this.pageNo, this.pageSize)
                .then(response => {

                    this.$blockUI.Stop();
                    this.Years = response.data.years;
                    this.pages = response.data.count;
                })
                .catch((err) => {
                    this.$blockUI.Stop();
                    console.error(err);
                    this.pages = 0;
                });
        },

        viewStudent(item)
        {
            this.state=2;
            this.selectedStudent=item;
        },


        deleteYears(id) {


            this.$confirm('سيؤدي ذلك إلى حدف السنة الدراسية  . استمر؟', 'تـحذير', {
                confirmButtonText: 'نـعم',
                cancelButtonText: 'لا',
                type: 'warning'
            }).then(() => {


                this.$http.deleteYears(id)
                    .then(response => {
                        this.$message({
                            type: 'info',
                            message: response.data
                        });
                        this.$blockUI.Stop();
                        this.GetYearsInfo();
                    })
                    .catch((err) => {
                        this.$blockUI.Stop();
                        this.$message({
                            type: 'error',
                            message: err.response.data
                        });
                    });
            });
        },
    }    
}
