import React from 'react';
import { useNavigate } from 'react-router-dom';
import Classes from './TourItem.css';

const TourItem = (props) => {
    let navigate = useNavigate();
    return (
        <div className={Classes.tour}>
            <img src={props.tour.mainPhoto} />
            <div className={Classes.tour_content}>
                <strong>{props.number}.{props.tour.title}</strong>
                <div>
                    {props.tour.body}
                </div>
            </div>
            <div className={Classes.tour_btns}>
                <Button color="secondary" outline onClick={() => props.remove(props.tour)}>Remove</Button>
                <Button color="primary" outline onClick={() => navigate(`/tour/${props.tour.id}`)}>Open</Button>
            </div>
        </div>
    );
}

export default TourItem;