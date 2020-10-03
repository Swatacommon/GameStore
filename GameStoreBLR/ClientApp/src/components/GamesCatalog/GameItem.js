import React, { Component } from 'react';
import { Redirect } from 'react-router-dom';

export class GameItem extends Component {
    constructor(props) {
        super(props);
        this.state = { image: null, loading: false, logged: true, orderState: 'Add to cart' };

        this.addToCard = this.addToCard.bind(this);
    }

    async addToCard(id) {
        const token = sessionStorage.getItem('tokenKey');
        const response = await fetch(`api/order/tocard/${id}`, {
            method: "GET",
            headers: {
                "Accept": "application/json",
                "Authorization": "Bearer " + token
            }
        });
        if (response.ok === true) {
            this.setState({ orderState: "Added" });
        } else {
            this.setState({ logged: false });
        }
        setTimeout(() => {
            this.setState({ orderState: "Add to cart" });
        }, 3000);
    }

    static renderGameItem(game, addToCard, orderState) {
        let imgUrl = 'http://localhost:5329/api/images/' + game.gameImages[0].imageNameNavigation.name + game.gameImages[0].imageNameNavigation.format;
        return (
            <div className="gameCard">
                <input type="button" value={orderState} key={game.id} className="orderButton" onClick={() => addToCard(game.id)} />
                <img alt="GameImage" src={imgUrl} className="gameCardImage" />
                <div className="gameCardInfo">
                    <div className="gameCardInfoShadow">
                        <p>{game.name}</p>
                        <p className="gameCardInfoPrice">{game.price}</p>
                    </div>
                </div>
            </div>
        )
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : GameItem.renderGameItem(this.props.game, this.addToCard, this.state.orderState);

        if (this.state.logged === true) {
            return (
                <div>
                    {contents}
                </div>
            );
        } else {
            return <Redirect to="/authorization" />
        }
    }
}