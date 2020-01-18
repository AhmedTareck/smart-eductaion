import moment from 'moment';
import CryptoJS from 'crypto-js';

export default {
    name: 'Subscribes',    
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
        
        this.clintType = [
            {
                id: 0,
                name: "الـكل"
            },
                {
                    id: 1,
                    name: "أستاذ"
                },
                {
                    id: 2,
                    name: 'مركز تخصصي'
                }

        ];

        this.GetSubscribes();

    },
    components: {
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
            
            state: 0,
            
            pageNo: 1,
            pageSize: 2,
            pages: 0,

            clintType:[],
            TypeSelected:'',
            
            subscribes: [],

            
            
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




        GetSubscribes(pageNo) {
            this.pageNo = pageNo;
            if (this.pageNo === undefined) {
                this.pageNo = 1;
            }
            this.$blockUI.Start();
            this.$http.GetSubscribes(this.pageNo, this.pageSize, this.TypeSelected)
                .then(response => {
                    this.$blockUI.Stop();
                    this.subscribes = response.data.subscribes;
                    this.pages = response.data.count;
                })
                .catch((err) => {
                    this.$blockUI.Stop();
                    console.error(err);
                    this.pages = 0;
                });
        },

    }    
}
