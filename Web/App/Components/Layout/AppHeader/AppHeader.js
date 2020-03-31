export default {
    name: 'AppHeader',    
    created() { 
        var route = window.location.href.split("/")[3];
        this.pathChange(route);
    },
    data() {
        return {            
            loginDetails: null,
            active: 1,
            circleUrl: "https://cube.elemecdn.com/3/7c/3ea6beec64369c2642b92c6726f1epng.png",
            squareUrl: "https://cube.elemecdn.com/9/c2/f0ee8a3c7c9638a54940382568c9dpng.png",
            sizeList: ["large", "medium", "small"],
            NavBar: 'navbar navbar-main navbar-expand-lg bg-primary navbar-dark headroom',
        };
    },
  
    methods: {

        pathChange(route) {
            if (route === "Login") {
                this.NavBar = "navbar navbar-main navbar-expand-lg navbar-transparent headroom";
            } else if (route === "SignUp") {
                this.NavBar = "navbar navbar-main navbar-expand-lg navbar-transparent headroom";
            } else {
                this.NavBar = 'navbar navbar-main navbar-expand-lg bg-primary navbar-dark headroom';
            }
        },
        href(url, visbilty) {
            if (visbilty === 1) {
                this.NavBar = "navbar navbar-main navbar-expand-lg navbar-transparent headroom";
            } else {
                this.NavBar = "navbar navbar-main navbar-expand-lg bg-primary navbar-dark headroom";
            }
            this.$router.push(url);
        }
       
      
    }    
}
