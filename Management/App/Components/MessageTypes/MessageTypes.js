import addMessageTypes from './AddMessageTypes/AddMessageTypes.vue';
import editMessageTypes from './EditMessageTypes/EditMessageTypes.vue';
import moment from 'moment';
import CryptoJS from 'crypto-js';

export default {
    name: 'MessageType',    
    created() {
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
        this.GetMessageTypes(this.pageNo);
    },
    components: {
        'add-MessageTypes': addMessageTypes,
        'edit-MessageTypes': editMessageTypes
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
            SECRET_KEY:'',
            pageNo: 1,
            pageSize: 10,
            pages: 0,  
            MessageType: [],
            EditMessageTypeObj:[],
            state: 0,
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
            this.GetAdTypes(this.pageNo);
        },

        RedirectToAddComponent() {
            this.state = 1;
        },
        GetMessageTypes(pageNo) {
            this.pageNo = pageNo;
            if (this.pageNo === undefined) {
                this.pageNo = 1;
            }
            this.$blockUI.Start();
            this.$http.GetMessageTypes(this.pageNo, this.pageSize)
                .then(response => {
                    this.$blockUI.Stop();
                    this.MessageType = response.data.messageType;
                    this.pages = response.data.count;
                })
                .catch((err) => {
                    this.$blockUI.Stop();
                    console.error(err);
                    this.pages = 0;
                });
        },

        EditMessageType(MessageType) {
            this.state = 2;
            this.EditMessageTypeObj = MessageType;
        },

         DeleteMessageType(MessageTypeId) {
            this.$confirm('<strong>أنت علي وشك القيام بحدف نـوع الرسالة هل تريد الإستمرار ؟</strong>', 'تنبيه', {
                cancelButtonText: 'إلغاء',
                confirmButtonText: 'نعـم',
                type: 'warning',
                dangerouslyUseHTMLString: true
            }).then(() => {
                this.$http.DeleteMessageType(MessageTypeId)
                    .then(response => {
                        this.$message({
                            type: 'success',
                            dangerouslyUseHTMLString: true,
                            duration: 5000,
                            message: '<strong>' + response.data + '</strong>'
                        });
                        this.GetMessageTypes(this.pageNo);
                    })
                    .catch((err) => {
                        this.$message({
                            type: 'error',
                            dangerouslyUseHTMLString: true,
                            duration: 5000,
                            showClose: true,
                            message: '<strong>' + err.response.data + '</strong>'
                        });
                    });
            });
        },

 
       
    }    
}
