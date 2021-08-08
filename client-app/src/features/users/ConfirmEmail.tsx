import React from 'react'
import { useEffect } from 'react'
import { useState } from 'react'
import { toast } from 'react-toastify'
import { Button, Header, Icon, Segment } from 'semantic-ui-react'
import agent from '../../app/api/agent'
import useQuery from '../../app/common/Util/hooks'
import { useStore } from '../../app/stores/store'
import LoginForm from './LoginForm'

export default function ConfirmEmail() {

    const {modalStore} = useStore()
    const email = useQuery().get('email') as string
    const token = useQuery().get('token') as string

    const Status = {
        Verifying: 'Verifying',
        Failed: 'Failed',
        Success: 'Success'
    }

    const [status, setStatus] = useState(Status.Verifying);

    function handleConfirmEmailResend() {
        agent.Account.resendEmailConfirm(email).then(() => {
            toast.success('Verification email resent! Please check your inbox')
        }).catch(error => console.log(error))
    }

    useEffect(() => {
        agent.Account.verifyEmail(token,email).then(() => {
            setStatus(Status.Success)
        }).catch(() => {
            setStatus(Status.Failed)
        })
    }, [Status.Failed, Status.Success, email, token])

    function getBody() {
        switch (status) {
            case Status.Verifying:
                return<p>Verifying...</p>;
            case Status.Success:
                return (
                    <div>
                        <p>Email confirmed! You can now log in.</p>
                        <Button primary onClick={() => modalStore.openModal(<LoginForm />)}  size='huge' content='Log in here!'/>
                    </div>
                );
            case Status.Failed:
                return (
                    <div>
                        <p>Verification failed. You can try resending the verification link to your email.</p>
                        <Button primary onClick={handleConfirmEmailResend} size='huge' content='Resend email' />
                    </div>
                );   

        }
    }

    return (
        <Segment placeholder textAlign='center'>
            <Header>
                <Icon name='envelope'/>
            </Header>
            <Segment.Inline>
                {getBody()}
            </Segment.Inline>
        </Segment>
    )

}