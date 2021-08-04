import { observer } from 'mobx-react-lite';
import React from 'react';
import Calendar from 'react-calendar';
import { Header, Menu } from 'semantic-ui-react';
import { useStore } from '../../../app/stores/store';

export default observer(function ActivityFilters() {

    const{ activityStore} = useStore();

    return (
        <>
        <Menu vertical size='large' style={{width: '100%', marginTop: 28}}>
            <Header icon='filter' attached color='teal' content='Filters' />
            <Menu.Item 
                content = 'All Activities' 
                active={activityStore.predicate.has('all')}
                onClick={() => activityStore.setPredicate('all', true)}
                />
            <Menu.Item 
                content = "I'm Going" 
                active={activityStore.predicate.has('isGoing')}
                onClick={() => activityStore.setPredicate('isGoing', true)}
                />
            <Menu.Item 
                content = "I'm Hosting" 
                active={activityStore.predicate.has('isHost')}
                onClick={() => activityStore.setPredicate('isHost', true)}
                />
        </Menu>
        <Header />
        <Calendar 
            onChange={(date) => activityStore.setPredicate('startDate', (date as Date))}
            value={activityStore.predicate.get('startDate') || new Date()}
            />
        </>
    )
})