﻿import moment from 'moment';
import EditEvents from './EditEvents/EditEvents.vue';
export default {
    name: 'Events',
    
    created() { 
       // this.getyearName();
        this.getEventInfo();
    },
    components: {
        'EditEvents': EditEvents,
    },
    data() {
        return {

            state:0,

            pageNo: 1,
            pageSize: 5,
            pages: 0,

            Event: [],

            year: [],
            yearSelected:'',
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

        getEventInfo(pageNo) {
            this.pageNo = pageNo;
            if (this.pageNo === undefined) {
                this.pageNo = 1;
            }
            this.$blockUI.Start();
            this.$http.getEventInfo(this.pageNo, this.pageSize)
                .then(response => {

                    this.$blockUI.Stop();
                    this.Event = response.data.eventinfo;
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

        addYers() {
            this.state = 1;
        },


        deleteEvent(id) {


            this.$confirm('سيؤدي ذلك إلى حدف المادة الدراسية  . استمر؟', 'تـحذير', {
                confirmButtonText: 'نـعم',
                cancelButtonText: 'لا',
                type: 'warning'
            }).then(() => {


                this.$http.delteEvent(id)
                    .then(response => {
                        this.$message({
                            type: 'info',
                            message: response.data
                        });
                        this.$blockUI.Stop();
                        this.getEventInfo();
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
