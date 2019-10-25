import addMessageTypes from './AddMessageTypes/AddMessageTypes.vue';
import editMessageTypes from './EditMessageTypes/EditMessageTypes.vue';
import moment from 'moment';

export default {
    name: 'MessageType',    
    created() {

        var loginDetails = sessionStorage.getItem('currentUser');

        if (loginDetails != null) {
            this.loginDetails = JSON.parse(loginDetails);

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
            pageNo: 1,
            pageSize: 10,
            pages: 0,  
            MessageType: [],
            EditMessageTypeObj:[],
            state: 0,
        };
    },
    methods: {
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
