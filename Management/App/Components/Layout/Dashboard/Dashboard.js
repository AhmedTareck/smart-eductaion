import CryptoJS from 'crypto-js';
export default {
    name: 'appHeader',    
    created() { 
        this.SECRET_KEY = 'P@SSWORDTAMEME';
        var route = window.location.href.split("/")[3];
        console.log(route);
        this.pathChange(route);
        //var DataSession = this.decrypt(sessionStorage.getItem('currentUser'));
        this.loginDetails = this.decrypt(sessionStorage.getItem('currentUser'));
        if (this.loginDetails != null) {
            this.loginDetails = JSON.parse(this.loginDetails);
          
        } else {
            window.location.href = '/Security/Login';
        }
        this.GetMessagesUnRead();
        setInterval(() => this.GetMessagesUnRead(), 10000);  
        this.menuFlag[0] = 'nav-item active';
    },
    data() {
        return {            
            loginDetails: null,
            UnReadCount:0,
            active: 1,
            menuFlag: [10],
            SECRET_KEY:'',
            
        };
    },
  
    methods: {
        GetMessagesUnRead() {
            this.$http.GetMessages()
                .then(response => {
                
                    this.UnReadCount = response.data.unred;
                })
                .catch((err) => {
                });
        },
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
        
        pathChange(route) 
        {
            
            if (route == "/") 
            {
                this.active = 1;
            } 
            else if (route == "Inbox") 
            {
                this.active = 2;
            } 
            else if (route == "Sent") 
            {
                this.active = 3;
            }
            else if (route == "AdTypes") 
            {
                this.active = 4;
            }
            else if (route == "Branches") 
            {
                this.active = 5;
            }
            else if (route == "Users") 
            {
                this.active = 6;
            }
            else if (route == "NewMessage") {
                this.active = 7;
            }
            else if (route == "Archive") {
                this.active = 8;
            }
            else if (route == "Test") {
                this.active = 11;
            }
            else if (route == "DeletedMessage") {
                this.active = 9;
            } else if (route == "ControlMessages") {
                this.active = 10;
            }
            else 
            {
                this.active = 1;
            }
        },

        href(url, id) {
            for (var i = 0; i < 11; i++) {
                if (i == id) {
                    this.$set(this.menuFlag, id, 'nav-item active');
                } else {
                    this.$set(this.menuFlag, i, '');
                }
            }
            this.$router.push(url);
        },
        OpenDropDown() {
            var root = document.getElementById("DropDown");
            if (root.getAttribute('class') == 'dropdown') {
                root.setAttribute('class', 'dropdown open');
            } else {
                root.setAttribute('class', 'dropdown');
            }

        },

        // ********************** Template InterActive ***********
        OpenMenuByToggle() {
            var root = document.getElementsByTagName('html')[0]; // '0' to assign the first (and only `HTML` tag)
            if (root.getAttribute('class') == 'nav-open') {
                root.setAttribute('class', '');
            } else {
                root.setAttribute('class', 'nav-open');
            }
        },
        OpenNotificationMenu() {
            var root = document.getElementById("Notifications");
            if (root.getAttribute('class') == 'dropdown open') {
                root.setAttribute('class', 'dropdown');
            } else if (root.getAttribute('class') == 'dropdown') {
                root.setAttribute('class', 'dropdown open');
            }
        }
        //****************************************************************

      
    }    
}
