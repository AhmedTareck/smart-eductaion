import AppHeader from './AppHeader/AppHeader.vue';
import AppFooter from './AppFooter/AppFooter.vue';
import Dashboard from './Dashboard/Dashboard.vue';
import CryptoJS from 'crypto-js';
import 'expose-loader?$!expose-loader?jQuery!jquery';

export default {
    
    name: 'layout',   
    
    components: 
    {
        'app-header': AppHeader,
        'app-footer': AppFooter,
        'app-dasboard': Dashboard,
    },
    
    created() 
    {
        this.SECRET_KEY = 'P@SSWORDTAMEME';
        this.$blockUI.$loading = this.$loading;
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

        $(document).ready(function ($) {
            "use strict";

	var treeviewMenu = $('.app-menu');

	// Toggle Sidebar
	$('[data-toggle="sidebar"]').click(function(event) {
		event.preventDefault();
		$('.app').toggleClass('sidenav-toggled');
	});

	// Activate sidebar treeview toggle
	$("[data-toggle='treeview']").click(function(event) {
		event.preventDefault();
		if(!$(this).parent().hasClass('is-expanded')) {
			treeviewMenu.find("[data-toggle='treeview']").parent().removeClass('is-expanded');
		}
		$(this).parent().toggleClass('is-expanded');
	});

	// Set initial active toggle
	$("[data-toggle='treeview.'].is-expanded").parent().toggleClass('is-expanded');

	//Activate bootstrip tooltips
	//$("[data-toggle='tooltip']").tooltip();


          });


    },
   
    data() {
        return {
            SECRET_KEY: '',
            isAuthenticated: false,
            isActive: false
        };
    },
    methods: {
        href(path) {
            this.$router.push(path);
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


      


    }
    
}
