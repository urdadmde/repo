SYNTAXDEF urdad
FOR <http://www.urdad.org/2010/urdad>
START Model

TOKENS {
	DEFINE COMMENT $'//'(~('\n'|'\r'|'\uffff'))*$;
	DEFINE INTEGER $('-')?('1'..'9')('0'..'9')*|'0'$;
	DEFINE FLOAT $('-')?(('1'..'9') ('0'..'9')* | '0') '.' ('0'..'9')+ $;
}


TOKENSTYLES {
	"model" COLOR #7F0055, BOLD;
	"responsibilityDomain" COLOR #7F0055, BOLD;
	"dataTypes" COLOR #7F0055, BOLD;
	"services" COLOR #7F0055, BOLD;
	"functionalConstraints" COLOR #7F0055, BOLD;
	"qualityRequirements" COLOR #7F0055, BOLD;
	"language" COLOR #7F0055, BOLD;
	"expression" COLOR #7F0055, BOLD;
	"constraintExpression" COLOR #7F0055, BOLD;
	"rangeConstraint" COLOR #7F0055, BOLD;
	"datatype" COLOR #7F0055, BOLD;
	"dataStructure" COLOR #7F0055, BOLD;
	"is" COLOR #7F0055, BOLD;
	"exception" COLOR #7F0055, BOLD;
	"attribute" COLOR #7F0055, BOLD;
	"association" COLOR #7F0055, BOLD;
	"aggregation" COLOR #7F0055, BOLD;
	"composition" COLOR #7F0055, BOLD;
	"qualityRequirement" COLOR #7F0055, BOLD;
	"requiredBy" COLOR #7F0055, BOLD;
	"requirementExpression" COLOR #7F0055, BOLD;
	"functionalRequirement" COLOR #7F0055, BOLD;
	"functionalConstraint" COLOR #7F0055, BOLD;
	"preCondition" COLOR #7F0055, BOLD;
	"requiredService" COLOR #7F0055, BOLD;
	"postCondition" COLOR #7F0055, BOLD;
	"inverseService" COLOR #7F0055, BOLD;
	"service" COLOR #7F0055, BOLD;
	"request" COLOR #7F0055, BOLD;
	"result" COLOR #7F0055, BOLD;
	"process" COLOR #7F0055, BOLD;
	"activitySequence" COLOR #7F0055, BOLD;
	"background" COLOR #7F0055, BOLD;
	"concurrentActivities" COLOR #7F0055, BOLD;
	"switch" COLOR #7F0055, BOLD;
	"while" COLOR #7F0055, BOLD;
	"condition" COLOR #7F0055, BOLD;
	"activity" COLOR #7F0055, BOLD;
	"conditionalActivity" COLOR #7F0055, BOLD;
	"preConditionActivity" COLOR #7F0055, BOLD;
	"requestContraint" COLOR #7F0055, BOLD;
	"exceptionContraint" COLOR #7F0055, BOLD;
	"postConditionActivity" COLOR #7F0055, BOLD;
	"inverseRequestContraint" COLOR #7F0055, BOLD;
	"prePostConditionActivity" COLOR #7F0055, BOLD;
	"returnResultActivity" COLOR #7F0055, BOLD;
	"resultContraint" COLOR #7F0055, BOLD;
}

RULES {
	Model ::= "model" name[] "{" (responsibilityDomains)* "}";
	ResponsibilityDomain ::= "responsibilityDomain" name[] "{"
		("dataTypes" "{"(dataTypes)* "}")?
		("services" "{" (services)* "}")?
		("functionalConstraints" "{" (functionalConstraints)* "}" )?
		("qualityRequirements" "{" (qualityRequirements)* "}" )?
	 "}";

	Expression ::= "{" 
		"language" language ['"','"'] ";"  
		"expression" expressionString['"','"'] ";" "}";
	DefinedConstraint ::= name[] "{" 
		("constraintExpression" constraintExpression)? "}";	
	BooleanExpression ::= "{" 
		"language" language ['"','"'] ";"  
		"expression" expressionString['"','"'] ";" "}";

	RangeMultiplicityConstraint ::= "rangeConstraint" name[] "["minOccurs[] "," maxOccurs[] "]" ";";
	BasicDataType ::= "datatype" name[] ";";
	DataStructure ::= "dataStructure" name[] ("is" superType[])? "{" (attributes)* (associations)* "}";
	Exception ::= "exception" name[] ("is" superType[])? "{" (attributes)* (associations)* "}";
	Attribute ::= "attribute" type[] name[] ";";
	Association ::= "association" name[] relatedType[] (multiplicityConstraint)? ";"; 
	Aggregation ::= "aggregation" name[] relatedType[] (multiplicityConstraint)? ";"; 
	Composition ::= "composition" name[] relatedType[] (multiplicityConstraint)? ";"; 
	QualityRequirement ::= "qualityRequirement" name[] "{"  
		"requiredBy" requiredBy[]";"
		"requirementExpression" (requirementExpression)?
		"}";
	FunctionalRequirement ::= "functionalRequirement" name[] "{" 
		"requiredBy" requiredBy[] ";"
	 	"functionalConstraint" functionalConstraint[] ";" "}";
	
	PreCondition ::= "preCondition" name[] "{"  
		("constraintExpression" "'" constraintExpression "'" ";" )?
		("requiredService" requiredService[] ";" )?
		 "exception" exception[] ";" "}";
	PostCondition ::= "postCondition" name[] "{" 
		("constraintExpression" constraintExpression)?
		("requiredService" requiredService[] ";" )?
		("inverseService" inverseService[] ";" )? "}";
	
	Service ::= "service" name[] "{"  
	 "request" request 
	 "result" result  
	 (functionalRequirements )+
	 (qualityRequirements[] )*
	 (process)? "}";
	Process ::= "process" processActivity;
	ActivitySequence ::= "activitySequence" ("background" "=" background[])? "{"  (activities)* "}";
	ConcurrentActivities ::= "concurrentActivities" ("background" "=" background[])? "{" (activities)* "}";
	Switch ::= "switch" ("background" "=" background[])? "{" (conditionalActivities)* "}";
	
	While ::= "while" ("background" "=" background[])? "{" 
		"condition" condition ";" 
		"activity" activity ";"  "}";
		
	ConditionalActivity ::= "conditionalActivity" ("background" "=" background[])? "{" 
		"condition" condition ";" 
		"activity" activity ";"  "}";
	
	PreConditionActivity ::= "preConditionActivity" ("background" "=" background[])? "{"  
		("requestContraint" requestContraints ";" )* 
		"preCondition" preCondition[] ";" 
		("exceptionContraint" exceptionContraints ";" )* "}";
	
	PostConditionActivity ::= "postConditionActivity"  ("background" "=" background[])? "{"  
		("requestContraint" requestContraints ";" )* 
		"postCondition" postCondition[] ";" 
		("inverseRequestContraint" inverseRequestContraints ";" )* "}";
	
	PrePostConditionActivity ::= "prePostConditionActivity" ("background" "=" background[])? "{" 
		("requestContraint" requestContraints ";" )* 
		"preCondition" preCondition[] ";" 
		"postCondition" postCondition[] ";" 
		("exceptionContraint" exceptionContraints ";" )* 
		("inverseRequestContraint" inverseRequestContraints ";" )* "}";

	ReturnResultActivity ::= "returnResultActivity" ("background" "=" background[])? "{"  
		("resultContraint" resultContraints ";" )* "}";
}