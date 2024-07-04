fetch('https://localhost:7264/Pilotos/GetAll')
    .then(response => response.json())
    .then(pilotos => {
        const cuerpoTabla = document.querySelector('tbody')
        pilotos.forEach(piloto => {
            const row = document.createElement('tr')
            row.innerHTML += "<td>"+piloto.id + "</td>"
            row.innerHTML += "<td>"+piloto.name + "</td>"
            row.innerHTML += "<td>"+piloto.email + "</td>"
            row.innerHTML += "<td>"+piloto.nacionalidad + "</td>"
            row.innerHTML += "<td>"+piloto.cantHorasVuelo + "</td>"
            row.innerHTML += "<td><button type=\"button\" class=\"btn btn-danger\" id=\"botonEliminar\">Eliminar</button> "+
                            "<button type=\"button\" class=\"btn btn-success\" id=\"botonEditar\">Editar</button></td>"
            row.className += "m-3 text-center"

            cuerpoTabla.append(row)

            
        });
    });

$(document).ready(function(){
    $('tbody').on("click","#botonEliminar",function(event){
        const clickedRow = event.target.closest('tr');
        const id = clickedRow.cells[0].textContent;
        const nombre = clickedRow.cells[1].textContent;
        var respuesta = Boolean(confirm("esta seguro de eliminar el piloto: "+ nombre))
        if(respuesta){
            const url = 'https://localhost:7264/api/Piloto/'+id
            fetch(url,{
                method : "DELETE"
            })
            .then(respuesta => respuesta.json())
            .then(resp => {
                alert("Piloto Eliminado, ID: " + id + " Nombre: " + nombre)
                clickedRow.remove()
            })

        }
    })
})