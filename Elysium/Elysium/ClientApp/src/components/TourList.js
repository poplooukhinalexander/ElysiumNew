import React from 'react';
import TourItem from './TourItem';
import { CSSTransition, TransitionGroup } from 'react-transition-group';
import './TourList.css';

const TourList = ({ tours, title, remove, pageNum }) => {
    if (!tours.length) {
        return (
            <h1 style={{ textAlign: 'center' }}>No Tours!</h1>
        );
    }

    return (
        <div>
            <h1 style={{ textAlign: 'center' }}>{title}</h1>
            <TransitionGroup>
                {
                    tours.map(tourItem =>
                        <CSSTransition key={tourItem.id} timeout={500} classNames="tour">
                            <TourItem number={tourItem.index} remove={remove} post={tourItem} key={tourItem.id} pageNum={pageNum} />
                        </CSSTransition>)
                }
            </TransitionGroup>
        </div>
    );
}

export default TourList;