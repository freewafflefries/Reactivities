
import {Form, Formik, Field, FieldProps} from 'formik'
import * as Yup from 'yup'

import { observer } from 'mobx-react-lite'
import React from 'react'
import { useStore } from '../../app/stores/store'
//import MyTextInput from '../../app/common/form/MyTextInput'
//import MyTextArea from '../../app/common/form/MyTextArea'
import { Button, Loader } from 'semantic-ui-react'

interface Props {
    setEditMode: (editMode: boolean) => void;
}

export default observer (function ProfileEditForm({setEditMode}: Props) {
    const {profileStore: {profile, updateProfile}} = useStore()

    return (
        <>
        <Formik 
            initialValues={{displayName: profile?.displayName, bio: profile?.bio}}
            onSubmit={values => {
                updateProfile(values).then(() => {
                    setEditMode(false)
                })
            }}
            validationSchema={Yup.object({
                displayName: Yup.string().required()
            })}
            >
                {({isSubmitting, isValid, dirty, handleSubmit}) => {
                    <Form className='ui form'>
                        <Field>
                        {(props: FieldProps) => (
                                    <div style={{position: 'relative'}}>
                                        <Loader action={isSubmitting} />
                                        <textarea 
                                              placeholder='Display Name' name='displayName'
                                        />
                                    </div>
                                )}
                        <Field>

                        </Field>


                            
                            <textarea     rows={3} placeholder='Add your bio' name='bio' />
                            <Button
                                positive
                                type='submit'
                                loading={isSubmitting}
                                content='Update Profile'
                                floated='right'
                                disabled={!isValid || !dirty}

                                

                            />
                        </Field> 
                    </Form>
                }}
        </Formik>
        </>
    )
})