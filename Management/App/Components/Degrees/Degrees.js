import AddDegrees from './AddDegrees/AddDegrees.vue'
﻿import moment from 'moment';
export default {
    name: 'Degrees',
    
    created() { 
        this.GetYears();
        this.GetHomeWorck();
    },
    components: {
        'AddDegrees': AddDegrees,
    },
    data() {
        return {

            state:0,

            pageNo: 1,
            pageSize: 5,
            pages: 0,

            Years:[],
            YearSelected:'',

            Events:[],
            EventSelectd:'',


            homeWorck: [],
            selectedHomeWorck:[],
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
       
        GetYears(){
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

        getEvents() 
        {
            this.EventSelectd='';
            this.GetHomeWorck();
            this.$blockUI.Start();
            this.$http.GetEvents(this.YearSelected)

                .then(response => {

                    this.$blockUI.Stop();
                    this.Events = response.data.events;
                })
                .catch((err) => {
                    this.$blockUI.Stop();
                    console.error(err);
                });
        },

        GetHomeWorck(pageNo) {
            this.pageNo = pageNo;
            if (this.pageNo === undefined) {
                this.pageNo = 1;
            }
            this.$blockUI.Start();
            this.$http.GetHomeWorck(this.pageNo, this.pageSize, this.YearSelected,this.EventSelectd)
                .then(response => {

                    this.$blockUI.Stop();
                    this.homeWorck = response.data.presness;
                    this.pages = response.data.count;
                })
                .catch((err) => {
                    this.$blockUI.Stop();
                    console.error(err);
                    this.pages = 0;
                });
        },

        editHomeWorck(item) {
            this.selectedHomeWorck = item;
            this.state = 1;
        },

        delteHomeWorck(id) {


            this.$confirm('سيؤدي ذلك إلى حدف الواجب الدراسي  . استمر؟', 'تـحذير', {
                confirmButtonText: 'نـعم',
                cancelButtonText: 'لا',
                type: 'warning'
            }).then(() => {


                this.$http.delteHomeWorck(id)
                    .then(response => {
                        this.$message({
                            type: 'info',
                            message: response.data
                        });
                        this.$blockUI.Stop();
                        this.GetHomeWorck();
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
