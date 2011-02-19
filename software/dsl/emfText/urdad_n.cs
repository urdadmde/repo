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
	"QualityRequirement" COLOR #7F0055, BOLD;
	"isRequiredBy" COLOR #7F0055, BOLD;
	"FunctionalRequirement" COLOR #7F0055, BOLD;
	"requiresService" COLOR #7F0055, BOLD;
	"when" COLOR #7F0055, BOLD;
	"Service" COLOR #7F0055, BOLD;
	"Request" COLOR #7F0055, BOLD;
	"Result" COLOR #7F0055, BOLD;
	"Process" COLOR #7F0055, BOLD;
	"ActivitySequence" COLOR #7F0055, BOLD;
	"ConcurrentActivities" COLOR #7F0055, BOLD;
	"concurrent" COLOR #7F0055, BOLD;
	"blocking" COLOR #7F0055, BOLD;
	"oneOf" COLOR #7F0055, BOLD;
	"while" COLOR #7F0055, BOLD;
	"if" COLOR #7F0055, BOLD;
	"then" COLOR #7F0055, BOLD;
	"do" COLOR #7F0055, BOLD;
	"RequestConstraints" COLOR #7F0055, BOLD;
	"returnResult" COLOR #7F0055, BOLD;
	"ResultConstraints" COLOR #7F0055, BOLD;
	"Note" COLOR #7F0055, BOLD;
}

RULES {
	Model ::= "Model" name[]
	 (responsibilityDomains)*
	 ("(" (annotations)*")")?;
	 
	ResponsibilityDomain ::= "ResponsibilityDomain" name[] "{"
		(responsibilityDomains | dataTypes | services | annotations)*"}"; 

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
	 
	QualityRequirement ::= "QualityRequirement"   name[] ":" (qualityExpression)
		"isRequiredBy" requiredBy[]
	  ("(" (annotations)*")")?;
 		
	FunctionalRequirement ::= "FunctionalRequirement"
	 	"requiresService" requiredService[]
		"isRequiredBy" requiredBy[] 
		("when" (condition))?
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
	ConcurrentActivity ::= "concurrent" ("blocking" "=" "'" blocking[] "'" ":")?	activity;
	Switch ::= "oneOf" "{" (conditionalActivities)* "}";
	
	While ::= "while" condition  activity;
		
	ConditionalActivity ::= "if" condition "then" activity;
	
	ServiceRequestActivity ::= "do" service[]  
		("RequestConstraints" "{" (requestConstraints)* "}")? 
		("(" (annotations)*")")?;
		
	ReturnResultActivity ::= "returnResult"   
		("ResultConstraints" "{" (resultConstraints)*"}")? 
		("(" (annotations)*")")?;
		
	Annotation ::= "Note" language[] ":" content['"','"'];
}