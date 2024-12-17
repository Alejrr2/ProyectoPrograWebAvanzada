document.getElementById("askButton").addEventListener("click", function () {
    let userChoice = document.getElementById("userInput").value;
    let responseDiv = document.getElementById("response");

    let responseText = '';

    switch (userChoice) {
        case '1':
            responseText = "El menú del día incluye una pasta fresca con salsa de tomate y albahaca, acompañado de una ensalada mixta.";
            break;
        case '2':
            responseText = "Aceptamos pagos en efectivo, tarjeta de crédito y débito, además de pagos en línea a través de nuestra plataforma.";
            break;
        case '3':
            responseText = "Nuestro horario de atención es de lunes a viernes de 11:00 AM a 10:00 PM, y los fines de semana de 12:00 PM a 11:00 PM.";
            break;
        case '4':
            responseText = "Sí, ofrecemos entregas a domicilio a través de varias plataformas de delivery, como Uber Eats y Rappi.";
            break;
        case '5':
            responseText = "Sí, contamos con varias opciones vegetarianas, como pastas con salsa pesto y ensaladas sin ingredientes de origen animal.";
            break;
        case '6':
            responseText = "Nuestro plato más popular es la pasta Alfredo con pollo, es el favorito de muchos de nuestros clientes.";
            break;
        case '7':
            responseText = "Sí, aceptamos reservas. Puedes llamarnos o hacer una reserva en línea a través de nuestro sitio web.";
            break;
        case '8':
            responseText = "Estamos ubicados en la calle principal, en el centro de la ciudad. La dirección exacta es: Calle 10, N°123.";
            break;
        default:
            responseText = "Lo siento, no entendí tu opción. Por favor, elige un número del 1 al 8.";
            break;
    }

    responseDiv.innerHTML = responseText;
});