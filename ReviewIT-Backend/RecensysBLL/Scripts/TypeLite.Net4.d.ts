
 
 

 


declare module RecensysBLL.BusinessEntities {
	export const enum DataType {
		String = 0,
		Boolean = 1,
		Radio = 2,
		Checkbox = 3,
		Number = 4,
		Resource = 5
	}
	export class Article {
	}
	export class Field {
		DataType: RecensysBLL.BusinessEntities.DataType;
		Id: number;
		Input: boolean;
		Name: string;
	}
	export class Stage {
		Id: number;
		StageDetails: RecensysBLL.BusinessEntities.StageDetails;
		StageFields: RecensysBLL.BusinessEntities.StageFields;
	}
	export class StageDetails {
		Description: string;
		Name: string;
	}
	export class StageFields {
		Id: number;
		RequestedFields: RecensysBLL.BusinessEntities.Field[];
		VisibleFields: RecensysBLL.BusinessEntities.Field[];
	}
	export class Study {
		AvailableFields: RecensysBLL.BusinessEntities.Field[];
		Id: number;
		Researchers: RecensysBLL.BusinessEntities.User[];
		Sources: any[];
		Stages: RecensysBLL.BusinessEntities.Stage[];
		StudyDetails: RecensysBLL.BusinessEntities.StudyDetails;
	}
	export class StudyDetails {
		Description: string;
		Name: string;
	}
	export class User {
		FirstName: string;
		Id: number;
		LastName: string;
		Password: string;
		PasswordSalt: string;
		Username: string;
	}
}



