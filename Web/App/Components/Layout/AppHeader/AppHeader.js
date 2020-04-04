export default {
    name: 'AppHeader',    
     created() { 
        var route = window.location.href.split("/")[3];
       
        this.pathChange(route);

        var loginDetails = localStorage.getItem('currentUser'); 
        if (loginDetails !== null && loginDetails !== "null" && loginDetails !== undefined && localStorage.getItem('currentUser').slice(2, 10) !== "!DOCTYPE") {
            this.loginDetails = JSON.parse(loginDetails);
        } else {
           // localStorage.removeItem('currentUser');
            // this.CheckLoginStatus(2);
           // window.location.href = '/Login';
            this.$router.push('/Login');
        }
    },
    data() {
        return {            
            loginDetails: null,
            active: 1,
            circleUrl: "https://cube.elemecdn.com/3/7c/3ea6beec64369c2642b92c6726f1epng.png",
            squareUrl: "https://cube.elemecdn.com/9/c2/f0ee8a3c7c9638a54940382568c9dpng.png",
            sizeList: ["large", "medium", "small"],
            NavBar: 'navbar navbar-expand-lg navbar-dark bg-default',
        };
    },
  
    methods: {
        logout() {
            this.$http.Logout()
                .then(response => {
                    debugger;
                    localStorage.setItem('currentUser', null);
                    window.location.href = '/';
                })
                .catch((err) => {
                    debugger;
                    //localStorage.removeItem('currentUser');
                    localStorage.setItem('currentUser', null);
                    window.location.href = '/';
                });    
        },


        CheckLoginStatus(status) {
            this.$http.CheckLoginStatus()
                .then(response => {  
                    debugger;

                    if (response.data.slice(1, 9) !== "!DOCTYPE") {
                        if (status == 2) {
                            window.location.href = '/';
                        }
                    } else {
                        localStorage.setItem('currentUser', null);
                    }

                    
                   
                    
                    })
                .catch((err) => {
                    debugger;
                    //localStorage.setItem('currentUser',null);
                   // window.location.href = '/';
                    if (status == 1) {
                        localStorage.setItem('currentUser', null);
                        window.location.href = '/Login';
                    }

                    //localStorage.setItem('currentUser', null);
                    //this.$http.Logout()
                    //    .then(response => {
                    //        window.location.href = '/';
                    //    })
                    //    .catch((err) => {
                    //    }); 
                    });
        },

        pathChange(route) {
            if (route === "Login") {
                this.NavBar = "navbar navbar-main navbar-expand-lg navbar-transparent headroom";
            } else if (route === "SignUp") {
                this.NavBar = "navbar navbar-main navbar-expand-lg navbar-transparent headroom";
            } else {
                this.NavBar = 'navbar navbar-expand-lg navbar-dark bg-default';
            }
        },
        href(url, visbilty) {
            if (visbilty === 1) {
                this.NavBar = "navbar navbar-main navbar-expand-lg navbar-transparent headroom";
            } else {
                this.NavBar = "navbar navbar-expand-lg navbar-dark bg-default";
            }
            this.$router.push(url);
        }
    }    
}
