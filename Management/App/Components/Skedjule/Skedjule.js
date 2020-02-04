import SkedjuleInfo from './SkedjuleInfo/SkedjuleInfo.vue';
import EditSkedjule from './EditSkedjule/EditSkedjule.vue';
﻿import moment from 'moment';
export default {
    name: 'Skedjule',
    
    created() { 
        this.GetPresness();
        this.GetYears();
    },
    components: {
        'SkedjuleInfo': SkedjuleInfo,
        'EditSkedjule': EditSkedjule,
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

            Presness:[],

            selectedPresness:[],
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
        AddStudent()
        {
            this.state = 1;
        },

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
            
            this.EventSelectd = '';
            this.GetPresness(this.pageNo);
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

        GetPresness(pageNo) {
            this.presness=[],
            this.pageNo = pageNo;
            if (this.pageNo === undefined) {
                this.pageNo = 1;
            }
            this.$blockUI.Start();
            this.$http.GetPresness(this.pageNo, this.pageSize,this.EventSelectd)
                .then(response => {

                    this.$blockUI.Stop();
                    this.Presness = response.data.presness;
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
            this.state=1;
            this.selectedPresness=item;
        },

        editePresness(item) {
            this.state = 2;
            this.selectedPresness = item;
        },


        deltePresness(id) {


            this.$confirm('سيؤدي ذلك إلى حدف السجل  . استمر؟', 'تـحذير', {
                confirmButtonText: 'نـعم',
                cancelButtonText: 'لا',
                type: 'warning'
            }).then(() => {


                this.$http.deltePresness(id)
                    .then(response => {
                        this.$message({
                            type: 'info',
                            message: response.data
                        });
                        this.$blockUI.Stop();
                        this.getEvents();
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
