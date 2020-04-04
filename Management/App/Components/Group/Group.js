﻿import moment from 'moment';
import EditGroup from './EditGroup/EditGroup.vue';
import AddSGroup from './AddSGroup/AddSGroup.vue';
export default {
    name: 'Subject',
    
    created() { 
        this.GetGroupInfo();
    },
    components: {
        'EditGroup': EditGroup,
        'AddSGroup': AddSGroup,
    },
    data() {
        return {

            state:0,

            pageNo: 1,
            pageSize: 5,
            pages: 0,


            Group: [],
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

     

        GetGroupInfo(pageNo) {
            this.pageNo = pageNo;
            if (this.pageNo === undefined) {
                this.pageNo = 1;
            }
            this.$blockUI.Start();
            this.$http.GetGroupInfo(this.pageNo, this.pageSize)
                .then(response => {

                    this.$blockUI.Stop();
                    this.Group = response.data.group;
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

        addGroup() {
            this.state = 1;
        },


    }    
}
