import addBranches from './AddBranches/AddBranches.vue';
import editBranches from './EditBranches/EditBranches.vue';
import moment from 'moment';

export default {
    name: 'Branches',    
    created() {
        this.GetBranches(this.pageNo);
        
        this.permissions = [
                {
                    id: 1,
                    name: "الإدارات"
                },
                {
                    id: 2,
                    name: 'إدارة الفروع'
                },
                {
                    id: 3,
                    name: 'مكاتب اللإصدار'
                },
                {
                    id: 4,
                    name: 'المكاتب الخدمية'
                }

        ];

    },
    components: {
        'add-Branches': addBranches,
        'edit-Branches': editBranches
    },
    filters: {
        moment: function (date) {
            if (date === null) {
                return "فارغ";
            }
           // return moment(date).format('MMMM Do YYYY, h:mm:ss a');
            return moment(date).format('MMMM Do YYYY');
        }
    },
    data() {
        return {  
            pageNo: 1,
            pageSize: 10,
            pages: 0,  
            Branches: [],
            state: 0,

            permissions: [],
            permissionModale: [],
        };
    },
    methods: {

        //GetBranches()
        //{

        //    this.$blockUI.Start();
        //    this.$http.GetBranchesByLevel(this.permissionModale)

        //        .then(response => {
        //            this.$blockUI.Stop();
        //            this.Branches = response.data.branches;
        //        })
        //        .catch((err) => {
        //            this.$blockUI.Stop();
        //            console.error(err);
        //            this.pages = 0;
        //        });
        //},




        RefreshTheTable() {
            this.GetCountries(this.pageNo);
        },


        RedirectToAddComponent() {
            this.state = 1;
        },

        DeleteBranch(BranchId) {

        

            this.$confirm('<strong>أنت علي وشك القيام بحدف الإدارة / الفرع هل تريد الإستمرار ؟</strong>', 'تنبيه', {
                
                cancelButtonText: 'إلغاء',
                confirmButtonText: 'نعـم',
                type: 'warning',
                dangerouslyUseHTMLString: true
            }).then(() => {
                this.$http.DeleteBranch(BranchId)
                    .then(response => {    
                        this.$message({
                            type: 'success',
                            dangerouslyUseHTMLString: true,
                            duration: 5000,
                            message: '<strong>'+response.data+'</strong>'
                        });  
                        this.GetBranches(this.pageNo);
                    })
                    .catch((err) => {
                        this.$message({
                            type: 'error',
                            dangerouslyUseHTMLString: true,
                            duration: 5000,
                            showClose: true,
                            message: '<strong>' + err.response.data+'</strong>'
                        });  
                    });
            });
        },

        GetBranches(pageNo) {
            this.pageNo = pageNo;
            if (this.pageNo === undefined) {
                this.pageNo = 1;
            }
            this.$blockUI.Start();
            this.$http.GetBranches(this.pageNo, this.pageSize)
                .then(response => {
                    this.$blockUI.Stop();
                    this.Branches = response.data.branches;
                    this.pages = response.data.count;
                })
                .catch((err) => {
                    this.$blockUI.Stop();
                    console.error(err);
                    this.pages = 0;
                });
        },
        EditBranch(branch) {
            this.state = 2;
            this.branchEditObject = branch;
        }

 
       
    }    
}
