import { observer } from 'mobx-react-lite';
import React from 'react';
import { Link } from 'react-router-dom';
import { Container, Header, Segment, Image, Button, Divider } from 'semantic-ui-react';
import { useStore } from '../../app/stores/store';
import LoginForm from '../users/LoginForm';
import RegisterForm from '../users/RegisterForm';

export default observer ( function HomePage(){

    const {userStore, modalStore} = useStore();

    return (
        <Segment inverted textAlign='center' vertical className='masthead'>
            <Container text>
                <Header as='h1' inverted>
                    <Image size='massive' src='/assets/logo.png' alt='logo' style={{marginBottom: 12}}/>
                    Reactivities
                </Header>

                {userStore.isLoggedIn ? (
                    <>
                    <Header as='h2' inverted content='Welcome to Reactiviies' />
                    <Button as={Link} to='/activities' size='huge' inverted >
                        Go to Activities!
                    </Button>
                    </>
                ) : (
                    <>
                    <Button size='huge' inverted onClick={() => modalStore.openModal(<LoginForm />)}>
                        Login to see the Reactivities!
                    </Button>
                    <Button size='huge' inverted onClick={() => modalStore.openModal(<RegisterForm />)}>
                        Register!
                    </Button>
                    <Divider horizontal  inverted>Or</Divider>
                    <Button 
                        loading={userStore.fbLoading}
                        size='huge' 
                        inverted 
                        color='facebook'
                        content='Login with Fartbook'
                        onClick={() => userStore.facebookLogin()}
                        />
                    </>
                )}                
               
            </Container>
        </Segment>
    )
})