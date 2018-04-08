new Vue({
    el: "#MainDiv",
    created: function () {
        this.getData();
    },
    data: function () {
        return {
            vModel: [], search: "",
        }
    },
    methods: {
        getData: function () {
            var self = this;
            var urlQS = GetDataIndex.value;

            axios.get(urlQS)
                .then(function (response) {
                    self.vModel = response.data;
                })
                .catch(function (error) {
                    console.log(error);
                });
        },
        addElement: function (e) {
            e.preventDefault();
            var locationCreate = LocationCreate.value;
            window.location.href = locationCreate;
        },
    },
    computed: {
        filteredList: function () {
            return this.vModel.filter(item => {
                return item.Description.toLowerCase().includes(this.search.toLowerCase());
            });
        },
    },
});