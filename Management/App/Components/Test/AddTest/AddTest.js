
import moment from 'moment';
import CryptoJS from 'crypto-js';

export default {
    name: 'AddTest',    
    created() {
        this.SECRET_KEY = 'P@SSWORDTAMEME';
        try {
            this.loginDetails = this.decrypt(sessionStorage.getItem('currentUser'));
        } catch (error) {
            window.location.href = '/Security/Login';
        }

        if (this.loginDetails != null) {
            this.loginDetails = JSON.parse(this.loginDetails);

            if (this.loginDetails.userType != 1) {
                window.location.href = '/Security/Login';
            }
        }
        else {
            window.location.href = '/Security/Login';
        }
        this.GetBranches(this.pageNo);
        
        this.permissions = [
            {
                id: 0,
                name: "الـكل"
            },
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
            SECRET_KEY :'',
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
        hash: function hash(key) {
            key = CryptoJS.SHA256(key, SECRET_KEY);

            return key.toString();
        },
        encrypt: function encrypt(data) {
            var dataSet = CryptoJS.AES.encrypt(data.toString(), this.SECRET_KEY);
            dataSet = dataSet.toString();
            return dataSet;
        },
        decrypt: function decrypt(data) {
            var dataSet = CryptoJS.AES.decrypt(data, this.SECRET_KEY);
            var plaintext = dataSet.toString(CryptoJS.enc.Utf8);
            dataSet = plaintext.toString(CryptoJS.enc.Utf8);
            return dataSet;
        },

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
            this.$http.GetBranches(this.pageNo, this.pageSize, this.permissionModale)
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
