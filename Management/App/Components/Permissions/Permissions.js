﻿import moment from 'moment';
import EditPermissions from './EditPermissions/EditPermissions.vue';
import AddPermissions from './AddPermissions/AddPermissions.vue';
export default {
    name: 'Years',
    
    created() { 
        this.GetPermissionsInfo();
        
    },
    components: {
        'EditPermissions': EditPermissions,
        'AddPermissions': AddPermissions,
    },
    data() {
        return {

            state:0,
            loginDetails:null,
            pageNo: 1,
            pageSize: 5,
            pages: 0,

            Permissions:[],
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

        GetPermissionsInfo(pageNo) {
            this.pageNo = pageNo;
            if (this.pageNo === undefined) {
                this.pageNo = 1;
            }
            this.$blockUI.Start();
            this.$http.GetPermissionsInfo(this.pageNo, this.pageSize)
                .then(response => {
                    console.log(response.data);
                    this.$blockUI.Stop();
                    this.Permissions = response.data.permission;
                    this.pages = response.data.count;
                })
                .catch((err) => {
                    this.$blockUI.Stop();
                    console.error(err);
                    this.pages = 0;
                });
        },

       

        addPermissions() {
            this.state = 1;
        },


        deletePermissions(id) {


            this.$confirm('سيؤدي ذلك إلى حدف السنة الدراسية  . استمر؟', 'تـحذير', {
                confirmButtonText: 'نـعم',
                cancelButtonText: 'لا',
                type: 'warning'
            }).then(() => {


                this.$http.deletePermissions(id)
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
