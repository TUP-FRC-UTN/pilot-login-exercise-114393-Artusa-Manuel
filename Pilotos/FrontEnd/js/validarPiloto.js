$("#formPilotoNuevo").validate({
    rules:{
        name: {
            required :true,
        },
        password: {
            required :true,
        },
        email: {
            required :true,
            email : true
        },
        nacionalidad: {
            required :true,
        },
        horas: {
            required :true,
        }
        
    },
    messages : {
        name: {
            required :"ingresar nombre",
        },
        password: {
            required :"ingresar password",
        },
        email: {
            required :"ingresar email",
            email: "Debe ser un email válido"
        },
        nacionalidad: {
            required :"ingresar Nacionalidad",
        },
        horas: {
            required :"ingresar horas",
        }
    },

    submitHandler: function(form){
        const name = $("#inputName").val();
        const password = $("#inputPassword").val();
        const email = $("#inputEmail").val();
        const nacionalidadId = parseInt($("#selectNacionalidad").val());
        const horas = parseInt($("#inputHoras").val());
        

        const pilotoNuevo = {
            "name" : name,
            "email": email,
            "password": password,
            "nacionalidadId" : nacionalidadId,
            "cantHorasVuelo": horas
        };

        const pilotoJson = JSON.stringify(pilotoNuevo);

        console.log(pilotoJson);
        const url = 'https://localhost:7264/Pilotos/CrearPiloto'
        fetch(url,{
            method: "POST",
            body : pilotoJson,
            headers : {
                "Content-type": "application/json"
            }


        })
        .then((response) => {
            if (!response.ok) {
                return response.text().then(text => { throw new Error(text) });
            }
            return response.json();
        })
        .then((response) => {
            alert("Piloto agregado");
            console.log(response); // Para verificar la respuesta del servidor
            // form.submit(); No enviar el formulario HTML después del fetch
        })
        .catch(error => {
            alert("NO SE PUDO AGREGAR EL PILOTO: " + error.message);
        });

    }

});
