
 
 

 


declare module RecensysCoreRepository.DTOs {
	export const enum DataType {
		String = 0,
		Boolean = 1,
		Radio = 2,
		Checkbox = 3,
		Number = 4,
		Resource = 5
	}
	export const enum ResearcherRole {
		Researcher = 0,
		ResearchManager = 1
	}
	export class CriteriaDTO {
		Exclusions: FieldCriteriaDTO[];
		Inclusions: FieldCriteriaDTO[];
	}
	export class DistributionDTO {
		Distribution: System.Collections.Generic.KeyValuePair<ResearcherDetailsDTO, number>[];
		IsRandomized: boolean;
		StageId: number;
	}
	export class FieldCriteriaDTO {
		Field: FieldDTO;
		Id: number;
		Operator: string;
		Value: string;
	}
	export class FieldDTO {
		DataType: DataType;
		Id: number;
		Name: string;
	}
	export class ResearcherDetailsDTO {
		FirstName: string;
		Id: number;
	}
	export class StageDetailsDTO {
		Description: string;
		Id: number;
		Name: string;
	}
	export class StageFieldsDTO {
		AvailableFields: FieldDTO[];
		RequestedFields: FieldDTO[];
		VisibleFields: FieldDTO[];
	}
	export class StudyDetailsDTO {
		Description: string;
		Id: number;
		Name: string;
	}
	export class StudyResearcherDTO {
		FirstName: string;
		ResearcherId: number;
		Role: ResearcherRole;
	}
}
declare module System.Collections.Generic {
	export class KeyValuePair<TKey, TValue> {
		Key: TKey;
		Value: TValue;
	}
}


