import addUsers from './AddUsers/AddUsers.vue';
import editUsers from './EditUsers/EditUsers.vue';
import moment from 'moment';
import CryptoJS from 'crypto-js';
export default 
{

    name: 'Users',
    
        created() 
        {
            this.GetUsers(this.pageNo);
            this.getUserName();
          
            this.SECRET_KEY = 'P@SSWORDTAMEME';
            var loginDetails = sessionStorage.getItem('currentUser');

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
        
        
    
    
    
    },



    components: {
        'add-Users': addUsers,
        'edit-Users': editUsers
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
    
    data() {
        return {
            pageNo: 1,
            pageSize: 10,
            pages: 0,
            Users: [],
            
            state: 0,
            
            EditUsersObj: [],
            
            loginDetails: '',

            UserName: [],
            selectedName: '',
            UserType:1,
            

        };
        },


    methods: 
    {
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

        EditUser(User) {
            this.state = 2;
            this.EditUsersObj = User;
        },
        
        ActivateUser(UserId) {
            this.$confirm('سيؤدي ذلك إلى تفعيل المستخدم  . استمر؟', 'تـحذير', {
                confirmButtonText: 'نـعم',
                cancelButtonText: 'لا',
                type: 'warning'
            }).then(() => {


                this.$http.ActivateUser(UserId)
                    .then(response => {
                        if (this.Users.lenght === 1) {
                            this.pageNo--;
                            if (this.pageNo <= 0) {
                                this.pageNo = 1;
                            }
                        }
                        this.$message({
                            type: 'info',
                            message: 'تم تفعيل المستخدم بنجاح',
                        });
                        this.GetUsers();
                    })
                    .catch((err) => {
                        this.$message({
                            type: 'error',
                            message: err.response.data
                        });
                    });
            });

        },

        DeactivateUser(UserId) {


            this.$confirm('سيؤدي ذلك إلى ايقاف تفعيل المستخدم  . استمر؟', 'تـحذير', {
                confirmButtonText: 'نـعم',
                cancelButtonText: 'لا',
                type: 'warning'
            }).then(() => {


                this.$http.DeactivateUser(UserId)
                    .then(response => {
                        if (this.Users.lenght === 1) {
                            this.pageNo--;
                            if (this.pageNo <= 0) {
                                this.pageNo = 1;
                            }
                        }
                        this.$message({
                            type: 'info',
                            message: 'تم ايقاف التفعيل المستخدم بنجاح',
                        });
                        this.GetUsers();
                    })
                    .catch((err) => {
                        this.$message({
                            type: 'error',
                            message: err.response.data
                        });
                    });
            });
        },

        DeleteUser(UserId) {
            this.$confirm('سيؤدي ذلك إلى حدف المستخدم  . استمر؟', 'تـحذير', {
                confirmButtonText: 'نـعم',
                cancelButtonText: 'لا',
                type: 'warning'
            }).then(() => {

                this.$http.DeleteUser(UserId)
                    .then(response => {
                        if (this.Users.lenght === 1) {
                            this.pageNo--;
                            if (this.pageNo <= 0) {
                                this.pageNo = 1;
                            }
                        }
                        this.$message({
                            type: 'info',
                            message: 'تم حدف المستخدم بنجاح',
                        });
                        this.GetUsers();
                    })
                    .catch((err) => {
                        this.$message({
                            type: 'error',
                            message: err.response.data
                        });
                    });
            });

        },

        GetUsers(pageNo) {
            this.pageNo = pageNo;
            if (this.pageNo === undefined) {
                this.pageNo = 1;
            }
            this.$blockUI.Start();

            this.$http.GetUsers(this.pageNo, this.pageSize, 1, this.selectedName)
                .then(response => {
                    this.$blockUI.Stop();
                    this.Users = response.data.users;
                    this.pages = response.data.count;
                })
                .catch((err) => {
                    this.$blockUI.Stop();

                    this.pages = 0;
                });
        },

        getUserName() {
            this.$blockUI.Start();

            this.$http.getUserName(1)
                .then(response => {
                    this.$blockUI.Stop();
                    this.UserName = response.data.names;
                })
                .catch((err) => {
                    this.$blockUI.Stop();
                });
        }


        

        
    }
};
