const API_EVENTS = "https://localhost:7172/api/events"
let currentEventId = null;
async function loadEvents() {
    const response = await fetch(API_EVENTS);
    const events = await response.json();

    renderEvents(events);
}

function renderEvents(events) {
    const container = document.getElementById("eventsContainer");
    container.innerHTML = "";

    events.forEach(event => {
        const div = document.createElement("div");

        div.innerHTML = `
         <h3>${event.name}</h3>
         <p>${event.venue}</p>
         <button onclick="loadSeats(${event.id})"> ver asientos 
         </button>
        `;

        container.appendChild(div);

    });
}

async function loadSeats(eventId) {
    currentEventId = eventId;
    const response = await fetch(`https://localhost:7172/api/seats?eventId=${eventId}`);
    const seats = await response.json();

    renderSeats(seats);
}

function renderSeats(seats) {
    const container = document.getElementById("seatsContainer");
    container.innerHTML = "";

    seats.forEach(seat => {
        const div = document.createElement("div");
        div.classList.add("seat");
        if (seat.status === "Available") div.classList.add("available");
        if (seat.status === "Reserved") div.classList.add("reserved");
        if (seat.status === "Sold") div.classList.add("sold");

        div.innerText = seat.rowIdentifier + seat.seatNumber;
        if (seat.status === "Available") {
            div.onclick = () => reserveSeat(seat.id);
        }
        container.appendChild(div);
    });
}

async function reserveSeat(seatId) {
    const userId = 2;
    const response = await fetch(`https://localhost:7172/api/Reservations?seatId=${seatId}&userId=${userId}`,
        {
            method: `POST`
        }
    );
    if (response.ok) {
        alert("Asiento reservado con exito");
        loadSeats(currentEventId);
    }
    else {
        alert("Error al reservar el asiento");
    }
}
loadEvents();
