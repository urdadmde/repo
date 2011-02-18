SYNTAXDEF urdad
FOR <http://www.urdad.org/2010/urdad>
START Model

TOKENS {
	DEFINE COMMENT $'//'(~('\n'|'\r'|'\uffff'))*$;
	DEFINE INTEGER $('-')?('1'..'9')('0'..'9')*|'0'$;
	DEFINE FLOAT $('-')?(('1'..'9') ('0'..'9')* | '0') '.' ('0'..'9')+ $;
}


TOKENSTYLES {
	"Model" COLOR #7F0055, BOLD;
	"ResponsibilityDomain" COLOR #7F0055, BOLD;
	"Constraint" COLOR #7F0055, BOLD;
	"BasicDataType" COLOR #7F0055, BOLD;
	"DataStructure" COLOR #7F0055, BOLD;
	"is" COLOR #7F0055, BOLD;
	"Exception" COLOR #7F0055, BOLD;
	"hasAttribute" COLOR #7F0055, BOLD;
	"ofType" COLOR #7F0055, BOLD;
	"isAssociatedWith" COLOR #7F0055, BOLD;
	"has" COLOR #7F0055, BOLD;
	"contains" COLOR #7F0055, BOLD;
	"QualityOfService" COLOR #7F0055, BOLD;
	"isRequiredBy" COLOR #7F0055, BOLD;
	"QualityConstraint" COLOR #7F0055, BOLD;
	"FunctionalConstraint" COLOR #7F0055, BOLD;
	"conditionUnderWhichRequired" COLOR #7F0055, BOLD;
	"PreCondition" COLOR #7F0055, BOLD;
	"requires" COLOR #7F0055, BOLD;
	"raises" COLOR #7F0055, BOLD;
	"when" COLOR #7F0055, BOLD;
	"PostCondition" COLOR #7F0055, BOLD;
	"undoneVia" COLOR #7F0055, BOLD;
	"Service" COLOR #7F0055, BOLD;
	"Request" COLOR #7F0055, BOLD;
	"Result" COLOR #7F0055, BOLD;
	"Process" COLOR #7F0055, BOLD;
	"ActivitySequence" COLOR #7F0055, BOLD;
	"ConcurrentActivities" COLOR #7F0055, BOLD;
	"ConcurrentActivity" COLOR #7F0055, BOLD;
	"blocking" COLOR #7F0055, BOLD;
	"oneOf" COLOR #7F0055, BOLD;
	"while" COLOR #7F0055, BOLD;
	"if" COLOR #7F0055, BOLD;
	"then" COLOR #7F0055, BOLD;
	"check" COLOR #7F0055, BOLD;
	"RequestConstraints" COLOR #7F0055, BOLD;
	"ExceptionConstraints" COLOR #7F0055, BOLD;
	"ensure" COLOR #7F0055, BOLD;
	"UndoRequestConstraints" COLOR #7F0055, BOLD;
	"given" COLOR #7F0055, BOLD;
	"returnResult" COLOR #7F0055, BOLD;
	"ResultConstraints" COLOR #7F0055, BOLD;
	"Note" COLOR #7F0055, BOLD;
}

RULES {
	Model ::= "Model" name[]
	 (responsibilityDomains)*
	 ("(" (annotations)*")")?;
	 
	ResponsibilityDomain ::= "ResponsibilityDomain" name[] "{"
		(dataTypes | functionalConstraints | qualityConstraints | services | responsibilityDomains | annotations)*"}"; 

	Expression ::= language [] ":" expressionString['"','"'];
	
	GeneralConstraint ::= "Constraint" name[] (constraintExpression)? 
	  ("(" (annotations)*")")?;
	
	BooleanExpression ::=  language [] ":" expressionString['"','"'];

	RangeMultiplicity ::= "["minOccurs[] "," maxOccurs[] "]";
	BasicDataType ::= "BasicDataType" name[]	  
	  ("(" (annotations)*")")?;
	
	DataStructure ::= "DataStructure" name[] ("is" superType[])? "{"
	  (attributes)* (associations)* 
	  ("(" (annotations)*")")?"}";
	Exception ::= "Exception" name[] ("is" superType[])? "{" 
	  (attributes)* (associations)* 
	  ("(" (annotations)*")")?"}";
	
	Attribute ::= "hasAttribute" name[] "ofType" type[];
	Association ::= "isAssociatedWith" name[] "ofType" relatedType[] (multiplicityConstraint)?; 
	Aggregation ::= "has" name[] "ofType" relatedType[] (multiplicityConstraint)?; 
	Composition ::= "contains" name[] "ofType" relatedType[] (multiplicityConstraint)?;
	 
	QualityRequirement ::= "QualityOfService"   
		qualityConstraint[] 
		"isRequiredBy" requiredBy[]
	  ("(" (annotations)*")")?;
	  
	QualityConstraint ::= "QualityConstraint" name[] ":" (qualityExpression);	  
		
	FunctionalRequirement ::= "FunctionalConstraint" functionalConstraint[]  
		"isRequiredBy" requiredBy[] 
		("conditionUnderWhichRequired" (condition))?
	  ("(" (annotations)*")")?;
	
	PreCondition ::= "PreCondition" name[]
		("requires" requiredService[])?
		 "raises" exception[]
		("when" condition)?
	  ("(" (annotations)*")")?;

	PostCondition ::= "PostCondition" name[]
		("requires" requiredService[])?
		("undoneVia" inverseService[])? 
	  ("(" (annotations)*")")?;
	
	Service ::= "Service" name[] "{"
	 (functionalRequirements )*
	 (qualityRequirements )*
	 "Request" request   
	 "Result" result 
	 (process)? 
	  ("(" (annotations)*")")?"}";
	 
	Process ::= "Process" processActivity ("(" (annotations)*")")?;

	ActivitySequence ::= "ActivitySequence" "{" (activities)* "}";
	ConcurrentActivities ::= "ConcurrentActivities" "{" (activities)* "}";
	ConcurrentActivity ::= "ConcurrentActivity" ("(" "blocking" "=" blocking[]")")?
		activity;
	Switch ::= "oneOf" "{" (conditionalActivities)* "}";
	
	While ::= "while" condition  activity;
		
	ConditionalActivity ::= "if" condition "then" activity;
	
	PreConditionActivity ::= "check" preCondition[]  
		("RequestConstraints" "{" (requestConstraints)* "}")? 
		("ExceptionConstraints" "{" (exceptionConstraints)* "}")? 
		("(" (annotations)*")")?;
		
	
	PostConditionActivity ::= "ensure"  postCondition[]  
		("RequestConstraints" "{" (requestConstraints)* "}")? 
		("UndoRequestConstraints" "{" (inverseRequestConstraints)* "}")? 
		("(" (annotations)*")")?;
	
	PrePostConditionActivity ::=  
		"given" preCondition[] 
		"ensure" postCondition[] 
		("RequestConstraints" "{" (requestConstraints)*"}")? 
		("ExceptionConstraints" "{" (exceptionConstraints)*"}")? 
		("UndoRequestConstraints" "{" (inverseRequestConstraints)*"}")? 
		("(" (annotations)*")")?;

	ReturnResultActivity ::= "returnResult"   
		("ResultConstraints" "{" (resultConstraints)*"}")? 
		("(" (annotations)*")")?;
		
	Annotation ::= "Note" language[] ":" content['"','"'];
	
}