<template src="./MassageDetals.html">
</template>

<script src="./MassageDetals.js"></script>
<style>

    .unread {
        background-color: whitesmoke;
    }



    .TableRow:hover {
        box-shadow: 0 0 11px rgba(33,33,33,.2);
    }

    .comment-head h3 {
        margin: 20px 0;
        text-transform: uppercase;
        position: relative;
        text-align: center;
    }

    .TablesReplay {
        box-shadow: 0 0 11px rgba(33,33,33,.2);
    }
    /*! CSS Used from: https://colorlib.com/polygon/jeweler/css/bootstrap.min.css */
    a {
        background-color: transparent;
    }

        a:active, a:hover {
            outline: 0;
        }

    @media print {
        *, :after, :before {
            color: #000 !important;
            text-shadow: none !important;
            background: 0 0 !important;
            -webkit-box-shadow: none !important;
            box-shadow: none !important;
        }

        a, a:visited {
            text-decoration: underline;
        }

            a[href]:after {
                content: " (" attr(href) ")";
            }

            a[href^="#"]:after {
                content: "";
            }
    }

    * {
        -webkit-box-sizing: border-box;
        -moz-box-sizing: border-box;
        box-sizing: border-box;
    }

    :after, :before {
        -webkit-box-sizing: border-box;
        -moz-box-sizing: border-box;
        box-sizing: border-box;
    }

    a {
        color: #337ab7;
        text-decoration: none;
    }

        a:focus, a:hover {
            color: #23527c;
            text-decoration: underline;
        }

        a:focus {
            outline: thin dotted;
            outline: 5px auto -webkit-focus-ring-color;
            outline-offset: -2px;
        }

    .text-success {
        color: #3c763d;
    }

    .text-info {
        color: #31708f;
    }

    .text-warning {
        color: #8a6d3b;
    }

    .row {
        margin-right: -15px;
        margin-left: -15px;
    }

    .col-md-3, .col-sm-3, .col-xs-12 {
        position: relative;
        min-height: 1px;
        padding-right: 15px;
        padding-left: 15px;
    }

    .col-xs-12 {
        float: left;
    }

    .col-xs-12 {
        width: 100%;
    }

    @media (min-width:768px) {
        .col-sm-3 {
            float: left;
        }

        .col-sm-3 {
            width: 25%;
        }
    }

    @media (min-width:992px) {
        .col-md-3 {
            float: left;
        }

        .col-md-3 {
            width: 25%;
        }
    }

    .panel-body {
        padding: 15px;
    }

    .panel-footer {
        padding: 10px 15px;
        background-color: #f5f5f5;
        border-top: 1px solid #ddd;
        border-bottom-right-radius: 3px;
        border-bottom-left-radius: 3px;
    }

    .panel-body:after, .panel-body:before, .row:after, .row:before {
        display: table;
        content: " ";
    }

    .panel-body:after, .row:after {
        clear: both;
    }
    /*! CSS Used from: https://colorlib.com/polygon/jeweler/css/font-awesome.min.css */
    .fa {
        display: inline-block;
        font: normal normal normal 14px/1 FontAwesome;
        font-size: inherit;
        text-rendering: auto;
        -webkit-font-smoothing: antialiased;
        -moz-osx-font-smoothing: grayscale;
    }

    .fa-file-pdf-o:before {
        content: "\f1c1";
    }

    .fa-file-excel-o:before {
        content: "\f1c3";
    }

    .fa-file-audio-o:before {
        content: "\f1c7";
    }
    /*! CSS Used from: https://colorlib.com/polygon/jeweler/css/normalize.css */
    a {
        background-color: transparent;
    }

        a:active, a:hover {
            outline: 0;
        }
    /*! CSS Used from: https://colorlib.com/polygon/jeweler/css/main.css */
    ::-moz-selection {
        background: #b3d4fc;
        text-shadow: none;
    }

    ::selection {
        background: #b3d4fc;
        text-shadow: none;
    }

    @media print {
        *, *:before, *:after {
            background: 0 0 !important;
            color: #000 !important;
            box-shadow: none !important;
            text-shadow: none !important;
        }

        a, a:visited {
            text-decoration: underline;
        }

            a[href]:after {
                content: " (" attr(href) ")";
            }

            a[href^="#"]:after {
                content: "";
            }
    }
    /*! CSS Used from: https://colorlib.com/polygon/jeweler/style.css */
    a:focus {
        outline: 0 solid;
    }

    a {
        transition: all .3s ease 0s;
        text-decoration: none;
    }

        a:hover {
            color: #ec4445;
            text-decoration: none;
        }

        a:visited, a:link, a:active {
            text-decoration: none;
        }

        a:active, a:hover {
            outline: 0;
        }

    .hpanel .panel-body {
        background: #fff;
        border-radius: 2px;
        padding: 15px;
        position: relative;
        -webkit-box-shadow: 0 1px 2px 0 rgba(0,0,0,.1);
        box-shadow: 0 1px 2px 0 rgba(0,0,0,.1);
    }

    .panel-body {
        padding: 15px;
        background: #fff;
    }

    .text-info {
        color: #3498db;
    }

    .text-warning {
        color: #ffb606;
    }

    .panel-footer {
        background: #ddd;
    }

    .file-body i.fa {
        font-size: 40px;
    }

    .incon-ctn-view {
        text-align: center;
    }
    /*! CSS Used fontfaces */
    @font-face {
        font-family: 'FontAwesome';
        src: url('https://colorlib.com/polygon/jeweler/fonts/fontawesome-webfont.eot?v=4.5.0');
        src: url('https://colorlib.com/polygon/jeweler/fonts/fontawesome-webfont.eot#iefix&v=4.5.0') format('embedded-opentype'),url('https://colorlib.com/polygon/jeweler/fonts/fontawesome-webfont.woff2?v=4.5.0') format('woff2'),url('https://colorlib.com/polygon/jeweler/fonts/fontawesome-webfont.woff?v=4.5.0') format('woff'),url('https://colorlib.com/polygon/jeweler/fonts/fontawesome-webfont.ttf?v=4.5.0') format('truetype'),url('https://colorlib.com/polygon/jeweler/fonts/fontawesome-webfont.svg?v=4.5.0#fontawesomeregular') format('svg');
        font-weight: normal;
        font-style: normal;
    }

</style>

