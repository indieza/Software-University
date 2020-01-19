export function venueTemplate() {
    return `<div class="venue" id="{{venueId}}">
    <span class="venue-name"><input class="info" type="button" value="More info">{{venueName}}</span>
    <div class="venue-details" style="display: none;">
        <table>
            <tr>
                <th>Ticket Price</th>
                <th>Quantity</th>
                <th></th>
            </tr>
            <tr>
                <td class="venue-price">{{venuePrice}} lv</td>
                <td><select class="quantity">
                        <option value="1">1</option>
                        <option value="2">2</option>
                        <option value="3">3</option>
                        <option value="4">4</option>
                        <option value="5">5</option>
                    </select></td>
                <td><input class="purchase" type="button" value="Purchase"></td>
            </tr>
        </table>
        <span class="head">Venue description:</span>
        <p class="description">{{venueDescription}}</p>
        <p class="description">Starting time: {{venueStartingHour}}</p>
    </div>
</div>`
}

export function confirmationTemplate() {
    return `<span class="head">Confirm purchase</span>
    <div class="purchase-info">
        <span>{{name}}</span>
        <span>{{qty}} x {{price}}</span>
        <span>Total: {{totalPrice}} lv</span>
        <input type="button" value="Confirm">
    </div>`;
}