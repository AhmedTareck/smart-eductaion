

export default {
    name: 'Content',
    props:['lecture'],
    components: {
        
    },
    created() {
    },
    data() {
        return {
            tabIndex : 0
        }
    },
    methods: {
        setTabIndex(index){
            this.tabIndex = index
        }
    }
}
