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
        deleteElement: function (item) {
            var getDelete = LocationDelete.value
            axios.get(getDelete + item.KeyId)
                .then(response => {
                    if (response.data) {
                        let index = this.vModel.indexOf(item);
                        this.vModel.splice(index, 1);
                        toastr.success("Archivo removido.", "Exito");
                        $('#deleteModal').modal('hide');

                    }
                    else if (!response.data.res) {
                        $('#deleteModal').modal('hide');
                        toastr.error(response.data.msj, "Error");
                    }
                })
                .catch(function (error) {
                    console.log(error)
                });
        }
    },
    computed: {
        filteredList: function () {
            return this.vModel.filter(item => {
                return item.Description.toLowerCase().includes(this.search.toLowerCase());
            });
        },
    },
});