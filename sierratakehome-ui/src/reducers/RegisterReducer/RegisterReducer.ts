import { RegisterAction, RegisterActionType } from "./RegisterActions";
import { RegisterState } from "./RegisterState";

export default (previousState: RegisterState, action: RegisterAction): RegisterState => {
  switch (action.type) {
    case RegisterActionType.UPDATE_REGISTER_FORM:
      return {
        ...previousState,
        username: action.username,
        password: action.password
      };

    case RegisterActionType.REGISTER_IN_PROGRESS:
      return previousState;

    case RegisterActionType.REGISTER_SUCCESS:
      return previousState;

    case RegisterActionType.REGISTER_ERROR:
      return previousState;
  }
}